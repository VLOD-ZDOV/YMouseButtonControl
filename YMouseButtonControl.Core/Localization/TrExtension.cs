using System;
using Avalonia.Markup.Xaml;

namespace YMouseButtonControl.Core.Localization;

/// <summary>
/// XAML markup extension that resolves a translation key to its localized string, e.g.
/// <c>Content="{i18n:Tr Btn_Apply}"</c>. The value is resolved once at load time, which is why a
/// language change requires an application restart (consistent with the Theme setting).
/// </summary>
public sealed class TrExtension : MarkupExtension
{
    public TrExtension() { }

    public TrExtension(string key) => Key = key;

    public string Key { get; set; } = string.Empty;

    public override object ProvideValue(IServiceProvider serviceProvider) =>
        Localizer.Instance[Key];
}
