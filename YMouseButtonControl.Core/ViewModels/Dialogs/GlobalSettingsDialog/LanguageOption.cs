using System.Collections.Generic;
using YMouseButtonControl.Core.Localization;

namespace YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog;

/// <summary>An entry in the language drop-down: a stored code plus its display name.</summary>
public sealed record LanguageOption(string Code, string Display)
{
    /// <summary>
    /// The selectable languages: "system" (follow the OS, label localized) followed by each
    /// supported language shown in its own name.
    /// </summary>
    public static IReadOnlyList<LanguageOption> All =>
        [
            new("system", Localizer.Instance["Set_LanguageSystem"]),
            new("en", "English"),
            new("ru", "Русский"),
            new("de", "Deutsch"),
            new("es", "Español"),
            new("fr", "Français"),
        ];
}
