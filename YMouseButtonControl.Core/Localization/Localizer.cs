using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ReactiveUI;

namespace YMouseButtonControl.Core.Localization;

/// <summary>
/// Tiny in-process translation table. Strings are looked up by key against the dictionary for the
/// active language, falling back to English (the source language) for any missing key.
///
/// Language is chosen once at startup (see App startup) and a change requires a restart, so the
/// markup extension resolves strings at XAML load time rather than via live bindings.
/// </summary>
public sealed class Localizer : ReactiveObject
{
    public static Localizer Instance { get; } = new();

    /// <summary>Language codes the UI offers explicitly, besides the implicit "system" option.</summary>
    public static readonly string[] SupportedLanguages = ["en", "ru", "de", "es", "fr"];

    private IReadOnlyDictionary<string, string> _current = Translations.En;

    private Localizer() { }

    /// <summary>
    /// Sets the active language. <paramref name="code"/> may be one of <see cref="SupportedLanguages"/>,
    /// or "system"/null/empty to follow the OS UI culture. Anything unsupported falls back to English.
    /// </summary>
    public void SetLanguage(string? code)
    {
        _current = Resolve(code) switch
        {
            "ru" => Translations.Ru,
            "de" => Translations.De,
            "es" => Translations.Es,
            "fr" => Translations.Fr,
            _ => Translations.En,
        };
    }

    /// <summary>Resolves a stored language code to one of <see cref="SupportedLanguages"/>.</summary>
    public static string Resolve(string? code)
    {
        if (string.IsNullOrWhiteSpace(code) || code == "system")
        {
            code = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        }

        return SupportedLanguages.Contains(code) ? code : "en";
    }

    public string this[string key] => Get(key);

    public string Get(string key)
    {
        if (_current.TryGetValue(key, out var value))
        {
            return value;
        }

        return Translations.En.TryGetValue(key, out var english) ? english : key;
    }

    /// <summary>Looks up a composite-format string and applies <paramref name="args"/>.</summary>
    public string Format(string key, params object?[] args) =>
        string.Format(CultureInfo.CurrentCulture, Get(key), args);
}
