# Architecture

YMouseButtonControl is a cross-platform clone of X-Mouse-Button-Control built with
[Avalonia](https://avaloniaui.net/) + [ReactiveUI](https://www.reactiveui.net/) (MVVM) on
.NET 8, with persistence through Entity Framework Core + SQLite.

## High-level flow

```
                 global mouse/keyboard hook (SharpHook / libuiohook)
                                  │
                                  ▼
        MouseListenerService ──► SkipProfile (per-OS) ──► KeyboardSimulatorWorker
                                  │                              │
                                  │                              ▼
                             ProfilesCache             simulated keys / mouse
                                  ▲                     (EventSimulatorService)
                                  │
            UI (Avalonia views) ◄─┴─► ViewModels ◄──► command/query handlers ◄──► DbContext
```

* **Input capture** – `MouseListenerService`
  (`Core/Services/KeyboardAndMouse/Implementations`) subscribes to a SharpHook
  `IReactiveGlobalHook`. For every mouse event it walks the active profiles and asks
  `ISkipProfile` whether each profile applies to the foreground window.
* **Profile matching** – `ISkipProfile` has a per-OS implementation
  (`SkipProfileWindows`, `SkipProfileLinux`, `SkipProfileOsx`). It returns `true` (skip)
  when the profile is unchecked, or when the foreground window doesn't match the profile's
  `Process`. `*` matches any window.
* **Action execution** – `KeyboardSimulatorWorker` plus the `SimulatedKeystrokesTypes`
  and `SimulatedMousePressTypes` services translate a button mapping into simulated input
  via `EventSimulatorService`.

## Projects and dependencies

```
Domain  ◄──  DataAccess (Infrastructure)  ◄──  Core  ◄──  App (YMouseButtonControl)
                                                  ▲
                                                  └── Tests
```

* **Domain** – POCO entities (`Profile`, `ButtonMapping` and its subclasses
  `NothingMapping` / `DisabledMapping` / `SimulatedKeystroke` / `RightClick`, `Setting`,
  `Theme`). No external dependencies.
* **DataAccess / Infrastructure** – `YMouseButtonControlDbContext` (SQLite). Schema and the
  built-in **Default** profile are defined in `OnModelCreating` via `HasData`, and migrations
  live under `Migrations/`. Button-mapping inheritance uses EF Core table-per-hierarchy.
* **Core** – the application logic:
  * **ViewModels** (`ViewModels/…`) – ReactiveUI view models, one per screen/dialog.
  * **Models / VMs** (`ViewModels/Models`) – `ProfileVm`, `BaseButtonMappingVm` and friends.
    These are the in-memory, observable representations the UI binds to.
  * **Mappers** (`Mappings/`) – `ProfileMapper` / `ButtonMappingMapper` convert between
    Domain entities and the `*Vm` view models.
  * **Command/Query handlers** – the codebase follows a lightweight CQRS style: each
    operation is a small static class containing a `Handler` (e.g.
    `ApplyProfiles.Handler`, `ListDbProfiles.Handler`, `GetCurrentWindow*`). Handlers are
    registered in DI and injected into view models.
  * **Services** – cross-cutting services (input, profiles cache, simulated input).
* **App (`YMouseButtonControl`)** – Avalonia views (`Views/*.axaml`), the program entry
  point, and the DI bootstrappers under `DependencyInjection/`.

## Profiles: in-memory cache vs. database

The UI never edits the database directly. Instead:

1. On startup `ProfilesCache` (`Core/Services/Profiles/ProfilesCache.cs`) loads all profiles
   from the DB via `ListDbProfiles.Handler` into a DynamicData `SourceCache<ProfileVm,int>`.
2. The UI binds to and mutates those `ProfileVm` objects. This makes the cache "dirty".
3. Pressing **Apply** runs `ApplyProfiles.Handler.ExecuteAsync`
   (`Core/ViewModels/MainWindow/Commands/Profiles/ApplyProfiles.cs`), which reconciles the
   cache against the database: it **adds** new profiles, **updates** existing ones (including
   each button mapping and the `Checked` flag), and **deletes** profiles removed from the cache,
   then calls `SaveChangesAsync`.

> The reconciliation loops are awaited (`foreach` + `await`). An earlier version used
> `List.ForEach(async …)`, producing fire-and-forget `async void` work over a non-thread-safe
> `DbContext`. With the synchronous SQLite provider those continuations usually complete inline
> (so this was not, by itself, the cause of the "doesn't save" reports), but the pattern is a
> latent correctness bug and has been removed. `ApplyProfilesTests` characterizes the save path.

### Where the database lives

The connection string in `appsettings.json` is intentionally relative
(`Data Source=YMouseButtonControl.db`). At startup `App` rebases it (and the log path) to an
absolute, per-user, writable directory via
`SqliteConnectionStringHelper.ToAbsolute(...)` + `App.GetUserDataDirectory()`
(`%APPDATA%` / `~/.config` / macOS config dir).

> **This was the real root cause of issues #41 / #35 / #32.** A relative SQLite data source is
> resolved against the process' *current working directory*; that directory differs between a
> normal launch and an autostart launch, so the app used to read/write different database files
> and edits appeared not to persist. `DatabasePathTests` covers the rebasing and an end-to-end
> persist-across-launches scenario.

The context is registered with `AddDbContext` (Scoped) but resolved from the root provider, so
in practice a single long-lived `DbContext` is shared across the app.

## Dependency injection

`DependencyInjection/Bootstrapper.Register` wires everything up from a single place,
delegating to focused bootstrappers (`Services`, `Factories`, `KeyboardAndMouse`,
`ViewModels`, `Views`). OS-specific services are chosen at runtime in
`KeyboardAndMouseBootstrapper` (`ISkipProfile`, current-window queries, etc.).

> **Debug vs. Release input hook:** in `DEBUG` builds the global hook is a SharpHook
> `TestProvider` (no real input is captured); `RELEASE` builds use the real
> `SimpleReactiveGlobalHook`. Keep this in mind when "nothing happens" while debugging.

## Localization

UI strings are localized through a small in-process table rather than .NET satellite assemblies:

* `Core/Localization/Translations.cs` — one dictionary per language (`En`, `Ru`, `De`, `Es`,
  `Fr`). **English is the source of truth and defines every key**; other languages may omit keys
  and fall back to English. `LocalizationTests` enforces that the non-English tables have exactly
  the same keys and no blank values.
* `Core/Localization/Localizer.cs` — singleton that holds the active table and resolves keys
  (`Localizer.Instance["Key"]`, or `.Format("Key", arg)` for composite strings).
* `Core/Localization/TrExtension.cs` — the `{i18n:Tr Key}` XAML markup extension. It resolves the
  string **at load time**, which is why a language change requires a restart.

The language is stored as a `SettingString` named `Language` (`"system"` follows the OS UI
culture) and applied in `App` **before any window is created**. To **add a language**: add its
code to `Localizer.SupportedLanguages`, add a dictionary to `Translations`, wire it into
`Localizer.SetLanguage` and `LanguageOption.All`. To **add a string**: add the key to `En` (and
ideally the other tables) and reference it via `{i18n:Tr}` or `Localizer.Instance`.

## Platform notes

* **Linux/Wayland** cannot tell an application which window currently has keyboard focus, and
  cannot suppress the original mouse button. This limits profile matching and "block original
  input"/mode-6 behaviour on Wayland. X11 is recommended. See `docs/TROUBLESHOOTING.md`.
* **WINE/Proton matching (X11):** foreground detection reads `/proc/<pid>/cmdline` in addition to
  the executable link, so a profile can match the Windows `game.exe` even though the process'
  executable is the wine loader (`GetCurrentWindowLinuxX11`, issue #29).
* **More than 5 mouse buttons** is not supported: SharpHook/`libuiohook` only delivers
  `Button1`–`Button5`, so buttons 6+ never reach the app (issue #44).
