using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using YMouseButtonControl.Core.Localization;
using YMouseButtonControl.Core.ViewModels.App.Commands.StartupInstaller.Install;
using YMouseButtonControl.Core.ViewModels.App.Commands.StartupInstaller.Uninstall;
using YMouseButtonControl.Core.ViewModels.App.Queries.StartupInstaller.CanBeInstalled;
using YMouseButtonControl.Core.ViewModels.App.Queries.StartupInstaller.IsInstalled;
using YMouseButtonControl.Core.ViewModels.MainWindow;
using YMouseButtonControl.Core.Views;

namespace YMouseButtonControl.Core.ViewModels.App;

public interface IAppViewModel;

public class AppViewModel : ViewModelBase, IAppViewModel
{
    private bool _runAtStartupIsChecked;
    private bool _runAtStartupIsEnabled;
    private const string RunAtStartupChecked = "✅ ";
    private const string RunAtStartupNotChecked = "";
    private string _runAtStartupHeader = "";

    /// <summary>
    /// Tray menu headers come from the view model rather than XAML markup because App.axaml is
    /// loaded before the saved language is applied; the view model is constructed after.
    /// </summary>
    private static string FormatRunAtStartupHeader(bool isChecked) =>
        (isChecked ? RunAtStartupChecked : RunAtStartupNotChecked)
        + Localizer.Instance["Tray_RunAtStartup"];

    public AppViewModel(
        ICanBeInstalledHandler canBeInstalledHandler,
        IIsInstalledHandler isInstalledHandler,
        IInstallHandler installHandler,
        IUninstallHandler uninstallHandler,
        IMainWindow mainWindow,
        IMainWindowViewModel mainWindowViewModel
    )
    {
        RunAtStartupIsEnabled = canBeInstalledHandler.Execute();
        RunAtStartupIsChecked = isInstalledHandler.Execute();
        RunAtStartupHeader = FormatRunAtStartupHeader(RunAtStartupIsChecked);
        ExitCommand = ReactiveCommand.Create(() =>
        {
            if (
                Application.Current?.ApplicationLifetime
                is IClassicDesktopStyleApplicationLifetime lifetime
            )
            {
                lifetime.Shutdown();
            }
        });
        SetupCommand = ReactiveCommand.Create(() =>
        {
            if (
                Application.Current?.ApplicationLifetime
                is IClassicDesktopStyleApplicationLifetime lifetime
            )
            {
                if (lifetime.MainWindow is null)
                {
                    var mw = (Window)mainWindow;
                    mw.DataContext = mainWindowViewModel;
                    lifetime.MainWindow = mw;
                }
                lifetime.MainWindow?.Show();
            }
        });
        var runAtStartupCanExecute = this.WhenAnyValue(x => x.RunAtStartupIsEnabled);
        RunAtStartupCommand = ReactiveCommand.Create(
            () =>
            {
                if (isInstalledHandler.Execute())
                {
                    // uninstall
                    uninstallHandler.Execute();
                    RunAtStartupIsChecked = false;
                    RunAtStartupHeader = FormatRunAtStartupHeader(false);
                }
                else
                {
                    // install
                    installHandler.Execute();
                    RunAtStartupIsChecked = true;
                    RunAtStartupHeader = FormatRunAtStartupHeader(true);
                }
            },
            runAtStartupCanExecute
        );
    }

    public string ToolTipText => $"YMouseButtonControl v{GetType().Assembly.GetName().Version}";

    public string SetupHeader => Localizer.Instance["Tray_Setup"];

    public string ExitHeader => Localizer.Instance["Tray_Exit"];

    public bool RunAtStartupIsEnabled
    {
        get => _runAtStartupIsEnabled;
        set => this.RaiseAndSetIfChanged(ref _runAtStartupIsEnabled, value);
    }

    public bool RunAtStartupIsChecked
    {
        get => _runAtStartupIsChecked;
        set => this.RaiseAndSetIfChanged(ref _runAtStartupIsChecked, value);
    }

    public string RunAtStartupHeader
    {
        get => _runAtStartupHeader;
        set => this.RaiseAndSetIfChanged(ref _runAtStartupHeader, value);
    }

    public ReactiveCommand<Unit, Unit> ExitCommand { get; }
    public ReactiveCommand<Unit, Unit> SetupCommand { get; }
    public ReactiveCommand<Unit, Unit> RunAtStartupCommand { get; }
}
