# YMouseButtonControl

This is an attempt at a cross-platform clone of X-Mouse-Button-Control.

![YMouseButtonControl 0 22 0](https://github.com/user-attachments/assets/a42266b8-dead-4dfd-b894-2deba1e9aa7e)

## Usage

1. Download the latest release from the [Releases](https://github.com/FaithBeam/YMouseButtonControl/releases) page for your platform
     * Alternatively, download the latest build from the [Actions tab](https://github.com/FaithBeam/YMouseButtonControl/actions)
2. Extract the archive
3. Run YMouseButtonControl

## Language

YMouseButtonControl is localized into **English, Russian, German, Spanish and French**.
By default it follows your operating system's UI language; you can override it in
**Settings → Language**. Changing the language requires a restart (like the theme setting).

## Requirements

* [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  * On windows if you run YMouseButtonControl.exe, it will take you to the download automatically
  * Self-contained release archives bundle the runtime, so nothing extra is required for those

### Linux

*Ubuntu*: ```sudo apt install dotnet-runtime-8.0```

*Fedora*: ```sudo dnf install dotnet-runtime-8.0```

*Arch*: ```sudo pacman -S dotnet-runtime```

## OS Compatibility

Anything that can install .NET 8 should be able to run YMouseButtonControl

[.NET 8 Supported OS](https://github.com/dotnet/core/blob/main/release-notes/8.0/supported-os.md)

| **Operating System** | **Version** |
|----------------------|-------------|
| Windows 10           | 1607+       |
| Windows 11           | 22000+      |
| Ubuntu               | 20.04+      |
| macOS                | 12.0+       |

### Linux X11 vs. Wayland Considerations

* X11 is preferred when running this software: [More information](https://github.com/FaithBeam/YMouseButtonControl/wiki/Linux-X11-vs-Wayland-Considerations)

### Linux Issues

* [Linux Issues](https://github.com/FaithBeam/YMouseButtonControl/wiki/Linux-Issues)

## Build

### Requirements

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

### Build Commands

1. `git clone https://github.com/FaithBeam/YMouseButtonControl`
2. `cd YMouseButtonControl`
3. ```
   dotnet publish YMouseButtonControl/YMouseButtonControl.csproj \
       -c Release \
       -r YOUR_PLATFORM \
       -o bin \
       --self-contained true \
       /p:PublishSingleFile=true \
       /p:IncludeNativeLibrariesForSelfExtract=true \
       /p:EnableCompressionInSingleFile=true

   ```
    * YOUR_PLATFORM: win-x64, linux-x64, osx-x64, [more runtimes here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog)
4. YMouseButtonControl executable is located in bin folder

### Helper script

`scripts/build-release.sh` builds self-contained, single-file releases and strips files that
aren't needed to run (debug symbols, `LICENSE`):

```
scripts/build-release.sh                 # win-x64, linux-x64, osx-x64
scripts/build-release.sh linux-x64       # a single runtime
scripts/build-release.sh win-x64 osx-arm64
```

Output goes to `bin/publish-<rid>/`. Each folder contains the executable plus `appsettings.json`
(required at startup); the macOS build additionally ships the native `.dylib` files it needs.

## Troubleshooting

Having a problem (profiles not saving, Wayland limitations, per-app profiles, more than 5
buttons)? See [docs/TROUBLESHOOTING.md](docs/TROUBLESHOOTING.md).

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for build/test instructions and
[docs/ARCHITECTURE.md](docs/ARCHITECTURE.md) for a tour of the codebase.
