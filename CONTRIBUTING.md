# Contributing to YMouseButtonControl

Thanks for your interest in improving YMouseButtonControl! This document explains how to
build, run, and test the project, and the conventions the codebase follows.

## Prerequisites

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
* A working internet connection for the first `dotnet restore` (NuGet packages)

## Getting started

```bash
git clone https://github.com/FaithBeam/YMouseButtonControl
cd YMouseButtonControl
dotnet restore YMouseButtonControl.sln
dotnet build YMouseButtonControl.sln
```

> **Note:** `YMouseButtonControl.sln` is the solution that matches this source tree.
> The `YMouseButtonControl.slnx` file describes a different, in-progress project layout
> (split per-platform projects) and is not the active solution.

## Running the app

```bash
dotnet run --project YMouseButtonControl/YMouseButtonControl.csproj
```

> **Important for contributors:** In **Debug** builds the global mouse/keyboard hook is
> replaced with a SharpHook `TestProvider` (see
> `YMouseButtonControl/DependencyInjection/KeyboardAndMouseBootstrapper.cs`). This means a
> Debug build does **not** capture real mouse buttons — it is meant for UI work and tests.
> To exercise real input handling, build/run in **Release**:
>
> ```bash
> dotnet run -c Release --project YMouseButtonControl/YMouseButtonControl.csproj
> ```

## Running the tests

```bash
dotnet test YMouseButtonControl.sln
```

Tests live in `YMouseButtonControl.Tests`. They use xUnit and run the real data-access layer
against an in-memory SQLite database (a shared, open connection), so persistence behaviour is
exercised exactly as it is in production. When adding a feature that touches the database or a
command/query handler, please add a test alongside it.

## Project layout

| Project | Responsibility |
|---------|----------------|
| `YMouseButtonControl.Domain` | Plain entity/enum models (`Profile`, `ButtonMapping`, `Setting`, …). No dependencies. |
| `YMouseButtonControl.DataAccess` (`YMouseButtonControl.Infrastructure`) | EF Core `DbContext`, SQLite, migrations, and the seeded "Default" profile. |
| `YMouseButtonControl.Core` | ViewModels (ReactiveUI), services, mappers, and command/query handlers. The bulk of the logic. |
| `YMouseButtonControl` | Avalonia app: views (`.axaml`), platform entry point, and dependency-injection bootstrappers. |
| `YMouseButtonControl.Tests` | xUnit tests. |

See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for a deeper tour.

## Coding conventions

* **Formatting** is enforced with [CSharpier](https://csharpier.com/). Run it before committing:
  ```bash
  dotnet tool restore   # if a local tool manifest is present
  dotnet csharpier .
  ```
  Files listed in `.csharpierignore` are excluded.
* **Warnings are errors.** `YMouseButtonControl.Core` builds with `TreatWarningsAsErrors`,
  so keep the build clean.
* **Async:** never use `List.ForEach(async …)` or any other pattern that produces a
  fire-and-forget `async void`. Use an awaited `foreach`. (A real persistence bug was caused
  by exactly this — see `ApplyProfiles` and its regression tests.)
* **DbContext is not thread-safe.** Do not start overlapping operations on the same context
  instance.

## Submitting changes

1. Create a branch off `master`.
2. Make your change and add/adjust tests.
3. Run `dotnet csharpier .`, `dotnet build`, and `dotnet test`.
4. Open a pull request describing the change and linking any related issue.
