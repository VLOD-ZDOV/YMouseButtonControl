#!/usr/bin/env bash
#
# Builds self-contained, single-file releases of YMouseButtonControl and then
# removes build artifacts that aren't needed to run it (debug symbols, LICENSE).
#
# Usage:
#   scripts/build-release.sh                     # builds win-x64, linux-x64, osx-x64
#   scripts/build-release.sh linux-x64           # builds only the given RID(s)
#   scripts/build-release.sh win-x64 osx-arm64   # any RIDs you like
#
# Output goes to bin/publish-<rid>/ at the repo root.

set -euo pipefail

# Resolve repo root from this script's location, so it works from any CWD.
# Use `pwd -P` (physical path) to canonicalize symlinks: if the repo is reachable via
# more than one alias (a symlinked parent directory), building under a mix of both
# prefixes corrupts MSBuild's incremental cache (CS0006 / missing references), so we
# always pin to the single physical path regardless of how the script was invoked.
script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd -P)"
repo_root="$(cd "$script_dir/.." && pwd -P)"
project="$repo_root/YMouseButtonControl/YMouseButtonControl.csproj"

# Default target runtimes if none are passed on the command line.
rids=("$@")
if [ ${#rids[@]} -eq 0 ]; then
    rids=(win-x64 linux-x64 osx-x64)
fi

for rid in "${rids[@]}"; do
    out="$repo_root/bin/publish-$rid"
    echo ">> Building $rid -> $out"
    rm -rf "$out"

    dotnet publish "$project" \
        -c Release \
        -r "$rid" \
        -o "$out" \
        --self-contained true \
        /p:PublishSingleFile=true \
        /p:IncludeNativeLibrariesForSelfExtract=true \
        /p:EnableCompressionInSingleFile=true

    # Clean up files that are produced but not required to run the app.
    #   *.pdb   -> debug symbols
    #   LICENSE -> legal text, not loaded at runtime
    # Kept on purpose: the executable, appsettings.json (read at startup, required),
    # and any native *.dylib/*.so/*.dll the runtime needs beside the binary (e.g. macOS).
    find "$out" -maxdepth 1 -type f -name '*.pdb' -delete
    rm -f "$out/LICENSE"

    echo "   done. Remaining files:"
    ( cd "$out" && ls -1 )
    echo
done

echo "All builds complete."
