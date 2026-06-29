using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Styling;
using ReactiveUI;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Commands.Logging;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Commands.Settings;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Commands.StartMenuInstall;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Commands.StartMenuUninstall;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Logging;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.StartMenuInstallerStatus;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Themes;

namespace YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog;

public interface IGlobalSettingsDialogViewModel;

public class GlobalSettingsDialogViewModel : DialogBase, IGlobalSettingsDialogViewModel
{
    private GetBoolSetting.BoolSettingVm _startMinimizedSetting;
    private bool _loggingEnabled;
    private bool _startMenuChecked;
    private GetIntSetting.IntSettingVm _themeSetting;
    private ObservableCollection<ListThemes.ThemeVm> _themeCollection;
    private ListThemes.ThemeVm _selectedTheme;
    private ObservableCollection<LanguageOption> _languageCollection;
    private LanguageOption _selectedLanguage;
    private readonly ObservableAsPropertyHelper<bool>? _applyIsExec;
    private readonly ThemeVariant _themeVariant;

    public GlobalSettingsDialogViewModel(
        GetBoolSetting.Handler getBoolSettingHandler,
        IStartMenuInstallerStatusHandler startupMenuInstallerStatusHandler,
        IStartMenuInstallHandler startMenuInstallHandler,
        IStartMenuUninstallHandler startMenuUninstallHandler,
        EnableLogging.Handler enableLoggingHandler,
        DisableLogging.Handler disableLoggingHandler,
        GetLoggingState.Handler loggingStateHandler,
        GetIntSetting.Handler getIntSettingHandler,
        GetStringSetting.Handler getStringSettingHandler,
        UpdateSetting<int>.Handler updateSettingIntHandler,
        UpdateSetting<bool>.Handler updateSettingBoolHandler,
        UpdateSetting<string>.Handler updateSettingStringHandler,
        GetThemeVariant.Handler getThemeVariantHandler,
        ListThemes.Handler listThemesHandler
    )
    {
        _themeVariant = getThemeVariantHandler.Execute();
        StartMenuEnabled = !OperatingSystem.IsMacOS();
        _startMenuChecked = StartMenuEnabled && startupMenuInstallerStatusHandler.Execute();
        _startMinimizedSetting = getBoolSettingHandler.Execute(
            new Queries.Settings.Models.Query("StartMinimized")
        );
        _loggingEnabled = loggingStateHandler.Execute();
        _themeSetting = getIntSettingHandler.Execute(new Queries.Settings.Models.Query("Theme"));
        _themeCollection = [.. listThemesHandler.Execute()];
        _selectedTheme = _themeCollection.First(x => x.Id == _themeSetting.Value);
        _languageCollection = [.. LanguageOption.All];
        var currentLanguage = getStringSettingHandler.Execute(
            new Queries.Settings.Models.Query("Language")
        );
        _selectedLanguage =
            _languageCollection.FirstOrDefault(x => x.Code == currentLanguage)
            ?? _languageCollection.First();

        // Update the theme setting selected theme value
        this.WhenAnyValue(x => x.SelectedTheme).Subscribe(x => ThemeSetting.Value = x.Id);

        var startMinimizedChanged = this.WhenAnyValue(
            x => x.StartMinimized.Value,
            selector: val =>
                getBoolSettingHandler
                    .Execute(new Queries.Settings.Models.Query("StartMinimized"))
                    .Value != val
        );
        var loggingChanged = this.WhenAnyValue(
            x => x.LoggingEnabled,
            selector: val => val != loggingStateHandler.Execute()
        );
        var startMenuChanged = this.WhenAnyValue(
            x => x.StartMenuChecked,
            selector: val => StartMenuEnabled && val != startupMenuInstallerStatusHandler.Execute()
        );
        var themeChanged = this.WhenAnyValue(
            x => x.ThemeSetting.Value,
            selector: val =>
                getIntSettingHandler.Execute(new Queries.Settings.Models.Query("Theme")).Value
                != val
        );
        var languageChanged = this.WhenAnyValue(
            x => x.SelectedLanguage,
            selector: val =>
                val.Code
                != getStringSettingHandler.Execute(new Queries.Settings.Models.Query("Language"))
        );
        var applyIsExecObs = this.WhenAnyValue(x => x.AppIsExec);
        var canSave = startMinimizedChanged
            .Merge(loggingChanged)
            .Merge(startMenuChanged)
            .Merge(applyIsExecObs)
            .Merge(themeChanged)
            .Merge(languageChanged);
        ApplyCommand = ReactiveCommand.CreateFromTask(
            async () =>
            {
                if (LoggingEnabled != loggingStateHandler.Execute())
                {
                    if (LoggingEnabled)
                    {
                        enableLoggingHandler.Execute();
                    }
                    else
                    {
                        disableLoggingHandler.Execute();
                    }
                }

                if (
                    StartMenuEnabled
                    && StartMenuChecked != startupMenuInstallerStatusHandler.Execute()
                )
                {
                    if (StartMenuChecked)
                    {
                        startMenuInstallHandler.Execute();
                    }
                    else
                    {
                        startMenuUninstallHandler.Execute();
                    }
                }

                await updateSettingBoolHandler.ExecuteAsync(
                    new UpdateSetting<bool>.Command("StartMinimized", StartMinimized.Value)
                );
                await updateSettingIntHandler.ExecuteAsync(
                    new UpdateSetting<int>.Command("Theme", ThemeSetting.Value)
                );
                await updateSettingStringHandler.ExecuteAsync(
                    new UpdateSetting<string>.Command("Language", SelectedLanguage.Code)
                );
            },
            canSave
        );
        _applyIsExec = ApplyCommand.IsExecuting.ToProperty(this, x => x.AppIsExec);
    }

    private bool AppIsExec => _applyIsExec?.Value ?? false;

    public bool StartMenuChecked
    {
        get => _startMenuChecked;
        set => this.RaiseAndSetIfChanged(ref _startMenuChecked, value);
    }

    public bool StartMenuEnabled { get; init; }

    public GetBoolSetting.BoolSettingVm StartMinimized
    {
        get => _startMinimizedSetting;
        set => this.RaiseAndSetIfChanged(ref _startMinimizedSetting, value);
    }

    public bool LoggingEnabled
    {
        get => _loggingEnabled;
        set => this.RaiseAndSetIfChanged(ref _loggingEnabled, value);
    }

    public ListThemes.ThemeVm SelectedTheme
    {
        get => _selectedTheme;
        set => this.RaiseAndSetIfChanged(ref _selectedTheme, value);
    }

    public GetIntSetting.IntSettingVm ThemeSetting
    {
        get => _themeSetting;
        set => this.RaiseAndSetIfChanged(ref _themeSetting, value);
    }

    public ObservableCollection<ListThemes.ThemeVm> ThemeCollection
    {
        get => _themeCollection;
        set => this.RaiseAndSetIfChanged(ref _themeCollection, value);
    }

    public ObservableCollection<LanguageOption> LanguageCollection
    {
        get => _languageCollection;
        set => this.RaiseAndSetIfChanged(ref _languageCollection, value);
    }

    public LanguageOption SelectedLanguage
    {
        get => _selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref _selectedLanguage, value);
    }

    public ReactiveCommand<Unit, Unit> ApplyCommand { get; init; }

    public ThemeVariant ThemeVariant => _themeVariant;
}
