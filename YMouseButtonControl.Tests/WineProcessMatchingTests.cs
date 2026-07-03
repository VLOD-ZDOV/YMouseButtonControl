using System.Collections.Generic;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using YMouseButtonControl.Core.Services.KeyboardAndMouse.Enums;
using YMouseButtonControl.Core.Services.KeyboardAndMouse.EventArgs;
using YMouseButtonControl.Core.Services.KeyboardAndMouse.Implementations.Queries.CurrentWindow;
using YMouseButtonControl.Core.Services.KeyboardAndMouse.Implementations.Queries.SkipProfile;
using YMouseButtonControl.Core.ViewModels.Models;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Covers the Linux profile-matching contract, in particular WINE/Proton (issue #29): the X11
/// foreground identity includes the process command line, so a profile whose process is the
/// Windows <c>game.exe</c> matches even though the executable link points at the wine loader.
/// </summary>
public class WineProcessMatchingTests
{
    private sealed class FakeCurrentWindow(string foreground) : IGetCurrentWindow
    {
        public string ForegroundWindow { get; } = foreground;
    }

    private static ProfileVm Profile(string process, bool @checked = true) =>
        new(new List<BaseButtonMappingVm>())
        {
            Description = process,
            Name = process,
            Process = process,
            WindowCaption = "N/A",
            WindowClass = "N/A",
            ParentClass = "N/A",
            MatchType = "N/A",
            Checked = @checked,
        };

    private static NewMouseHookEventArgs Event() => new(YMouseButton.MouseButton4, 0, 0, null);

    private static bool ShouldSkip(string foreground, ProfileVm profile)
    {
        var sut = new SkipProfileLinux(
            NullLogger<SkipProfileLinux>.Instance,
            new FakeCurrentWindow(foreground)
        );
        return sut.ShouldSkipProfile(profile, Event());
    }

    [Fact]
    public void WineGame_MatchedViaCommandLine_NotSkipped()
    {
        // /exe points at the wine loader; the real exe is only in the command line.
        const string foreground =
            "/opt/wine/bin/wine64-preloader Z:\\games\\MyGame\\game.exe -windowed";

        Assert.False(ShouldSkip(foreground, Profile("game.exe")));
    }

    [Fact]
    public void NativeApp_MatchedViaExePath_NotSkipped()
    {
        const string foreground = "/usr/lib/firefox/firefox /usr/lib/firefox/firefox";
        Assert.False(ShouldSkip(foreground, Profile("firefox")));
    }

    [Fact]
    public void DifferentProcess_IsSkipped()
    {
        const string foreground = "/usr/lib/firefox/firefox";
        Assert.True(ShouldSkip(foreground, Profile("game.exe")));
    }

    [Fact]
    public void WildcardProfile_AlwaysMatches()
    {
        Assert.False(ShouldSkip("/usr/lib/firefox/firefox", Profile("*")));
    }

    [Fact]
    public void UncheckedProfile_IsSkipped()
    {
        const string foreground = "/opt/wine/bin/wine64-preloader Z:\\games\\game.exe";
        Assert.True(ShouldSkip(foreground, Profile("game.exe", @checked: false)));
    }
}
