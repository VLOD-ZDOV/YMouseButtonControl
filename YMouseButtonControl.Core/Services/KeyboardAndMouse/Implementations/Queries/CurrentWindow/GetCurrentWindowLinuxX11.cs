using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using YMouseButtonControl.Core.Services.KeyboardAndMouse.Implementations.Queries.CurrentWindow;

namespace YMouseButtonControl.Core.Services.KeyboardAndMouse.Implementations.MouseListener.Queries.CurrentWindow;

public class GetCurrentWindowLinuxX11 : IGetCurrentWindow
{
    public string ForegroundWindow => GetForegroundWindow();

    private static string GetForegroundWindow()
    {
        try
        {
            var display = X11.XOpenDisplay(nint.Zero);
            if (display == nint.Zero)
            {
                // No X11 display reachable (e.g. a native Wayland window is focused). Fall back to
                // matching every profile instead of throwing on the mouse-hook thread.
                return "*";
            }

            try
            {
                var pid = GetForegroundWindowPid(display);
                if (pid is null)
                {
                    return "";
                }

                return GetIdentityFromPid(pid.Value);
            }
            finally
            {
                X11.XCloseDisplay(display);
            }
        }
        catch
        {
            return "*";
        }
    }

    /// <summary>
    /// Builds the string a profile's process is matched against. It combines the executable path
    /// (<c>/proc/&lt;pid&gt;/exe</c>) with the process' command line (<c>/proc/&lt;pid&gt;/cmdline</c>).
    /// The command line is what lets WINE/Proton games match: their <c>/exe</c> link points at the
    /// wine loader, but the actual <c>game.exe</c> path appears as a command-line argument (#29).
    /// </summary>
    private static string GetIdentityFromPid(int pid)
    {
        var exe = new FileInfo($"/proc/{pid}/exe").LinkTarget ?? "";

        var cmdline = "";
        try
        {
            // cmdline arguments are NUL-separated; flatten to spaces so a simple Contains works.
            var raw = File.ReadAllBytes($"/proc/{pid}/cmdline");
            cmdline = Encoding.UTF8.GetString(raw).Replace('\0', ' ').Trim();
        }
        catch
        {
            // /proc entry may be unreadable (permissions/race); use the exe path alone.
        }

        return string.IsNullOrEmpty(cmdline) ? exe : $"{exe} {cmdline}";
    }

    private static unsafe int? GetForegroundWindowPid(nint display)
    {
        var root = X11.XDefaultRootWindow(display);
        var prop = X11.XInternAtom(display, Marshal.StringToHGlobalAnsi("_NET_ACTIVE_WINDOW"), 0);
        var pidProp = X11.XInternAtom(display, Marshal.StringToHGlobalAnsi("_NET_WM_PID"), 1);

        if (
            X11.XGetWindowProperty(
                display,
                root,
                prop,
                0,
                sizeof(ulong),
                0,
                0,
                out _,
                out _,
                out _,
                out _,
                out var outProp
            ) != 0
            || outProp == nint.Zero
        )
        {
            return null;
        }

        var activeWindow = *(nint*)outProp;
        X11.XFree(outProp);

        if (
            X11.XGetWindowProperty(
                display,
                activeWindow,
                pidProp,
                0,
                sizeof(int),
                0,
                0,
                out _,
                out _,
                out _,
                out _,
                out var prop2
            ) != 0
            || prop2 == nint.Zero
        )
        {
            return null;
        }

        var pid = *(int*)prop2;
        X11.XFree(prop2);
        return pid;
    }
}

internal static partial class X11
{
    [LibraryImport("libX11.so.6")]
    internal static partial int XFree(nint data);

    [LibraryImport("libX11.so.6")]
    internal static partial nint XOpenDisplay(nint display);

    [LibraryImport("libX11.so.6")]
    internal static partial void XCloseDisplay(nint display);

    [LibraryImport("libX11.so.6")]
    internal static partial nint XDefaultRootWindow(nint display);

    [LibraryImport("libX11.so.6")]
    internal static partial nint XInternAtom(nint display, nint atomName, int onlyIfExists);

    [LibraryImport("libX11.so.6")]
    internal static partial int XGetWindowProperty(
        IntPtr display,
        IntPtr window,
        IntPtr property,
        long longOffset,
        long longLength,
        int delete,
        ulong reqType,
        out ulong actualTypeReturn,
        out int actualFormatReturn,
        out ulong nItemsReturn,
        out ulong bytesAfterReturn,
        out IntPtr propReturn
    );
}
