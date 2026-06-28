# Troubleshooting & Known Issues

This page collects the most common problems reported on the issue tracker, with the cause and
the current status of each.

## Profiles / button mappings don't save (issues #41, #35, #32)

**Symptom:** You set a button (e.g. disabling MOUSE4/MOUSE5 or assigning Simulated Keys),
press **Apply** / **Save Profile**, but after restarting the app everything is back to
*"Do not intercept"*; or an **unchecked** profile is still active after a restart.

**Cause:** The database connection string was a **relative** path
(`Data Source=YMouseButtonControl.db`). A relative SQLite data source is resolved against the
process' **current working directory**, which differs between a normal launch and an
autostart launch (issue #32). The app therefore read and wrote *different database files*
depending on how it was started, so changes appeared not to persist and the seeded defaults
kept coming back.

**Status:** **Fixed.** The database (and log file) now resolve to an absolute, per-user
location:

* Windows: `%APPDATA%\YMouseButtonControl\YMouseButtonControl.db`
* Linux: `~/.config/YMouseButtonControl/YMouseButtonControl.db`
* macOS: under the user's config / Application Support directory

The path logic is covered by `YMouseButtonControl.Tests/DatabasePathTests.cs`. If you are on an
older build, update to a build that includes this fix. (Your previous settings lived in a
working-directory-dependent `YMouseButtonControl.db`; you may need to reconfigure once.)

> A related hardening change also fixed a latent `async void` pattern in the save path
> (`ApplyProfiles`); see `docs/ARCHITECTURE.md`.

## Simulated keys / mode 6 don't work on Wayland (issues #42, #36)

**Symptom:** Simulated keystrokes pop up an error, or a mapping only works while the
YMouseButtonControl window itself is focused; "block original mouse input" / mode 6 has no
effect.

**Cause:** Wayland intentionally does **not** let an application (a) query which window
currently has keyboard focus or (b) suppress the original mouse button. These capabilities
must be provided by the desktop environment, and GNOME/KDE do not expose them today. This is
a platform limitation, not a permissions issue — running with `sudo` does not help.

**Workaround:** Use an **X11** session. On X11, foreground-window detection works and original
input can be suppressed, so profile matching and mode 6 behave correctly.
See also the project wiki: *Linux X11 vs. Wayland Considerations*.

## A per-application profile never triggers on Linux (issue #46)

**Symptom:** You add a profile for, say, `firefox`, but it never activates; the log shows
`Couldn't find foreground window firefox` while another app (e.g. `konsole`) is focused.

**Things to check:**

1. **Are you on Wayland?** If so, see the section above — the foreground window cannot be
   detected and matching will not work. Switch to X11.
2. **Is the target app actually focused** when you click? The profile only applies while its
   window is in the foreground. The log line `Foreground window: /usr/bin/konsole` tells you
   what had focus at that moment.
3. **Process matching is a substring match** against the executable path. On X11 a profile
   whose `Process` is `firefox` matches a foreground path like `/usr/lib64/firefox/firefox`.
   If matching still fails, set the profile's process to the value shown after
   `Foreground window:` in the logs.

## Mouse buttons beyond 5 are not detected (issue #44)

**Symptom:** Buttons 6+ on a gaming mouse can't be mapped.

**Cause:** The OS-level input hooks only expose left/right/middle, the scroll wheel, and the
two extended buttons (XButton1/XButton2 = MB4/MB5). Anything beyond that requires a
vendor-specific driver per mouse model. This is **out of scope** for YMouseButtonControl.
On macOS, MB4/MB5 may not be reported at all.

## "Installation not working" with pip / Python errors (issue #45)

**Symptom:** Following some instructions leads to `error: externally managed environment` or
`Could not find a version that satisfies the requirement requirements-txt` from `pip`/`pipx`.

**Cause:** YMouseButtonControl is a **.NET 8** application — it has **nothing to do with
Python or pip**. Those errors come from following unrelated/incorrect instructions.

**Fix:** Install per the [README](../README.md): download the release archive for your
platform (or build with the .NET SDK) and run the `YMouseButtonControl` executable. The only
runtime requirement is the **.NET 8 Runtime**.

## "Nothing happens" while running a Debug build (for contributors)

In **Debug** builds the global input hook is replaced by a SharpHook `TestProvider`, so real
mouse buttons are not captured. Build/run in **Release** to test real input handling. See
[`CONTRIBUTING.md`](../CONTRIBUTING.md).
