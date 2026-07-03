using System.Linq;
using Xunit;
using YMouseButtonControl.Core.Localization;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Guards the translation tables: English is the source of truth and every other language must
/// define exactly the same set of keys, so nothing silently falls back to English at runtime.
/// </summary>
public class LocalizationTests
{
    public static TheoryData<string> NonEnglishLanguages =>
        new() { "ru", "de", "es", "fr", "uk", "pt", "zh" };

    [Theory]
    [MemberData(nameof(NonEnglishLanguages))]
    public void EveryLanguage_HasExactlySameKeysAsEnglish(string code)
    {
        var dict = code switch
        {
            "ru" => Translations.Ru,
            "de" => Translations.De,
            "es" => Translations.Es,
            "fr" => Translations.Fr,
            "uk" => Translations.Uk,
            "pt" => Translations.Pt,
            "zh" => Translations.Zh,
            _ => Translations.En,
        };

        var missing = Translations.En.Keys.Except(dict.Keys).ToList();
        var extra = dict.Keys.Except(Translations.En.Keys).ToList();

        Assert.True(missing.Count == 0, $"{code} is missing keys: {string.Join(", ", missing)}");
        Assert.True(extra.Count == 0, $"{code} has unknown keys: {string.Join(", ", extra)}");
    }

    [Theory]
    [MemberData(nameof(NonEnglishLanguages))]
    public void EveryLanguage_HasNoBlankTranslations(string code)
    {
        var dict = code switch
        {
            "ru" => Translations.Ru,
            "de" => Translations.De,
            "es" => Translations.Es,
            "fr" => Translations.Fr,
            "uk" => Translations.Uk,
            "pt" => Translations.Pt,
            "zh" => Translations.Zh,
            _ => Translations.En,
        };

        Assert.DoesNotContain(dict, kvp => string.IsNullOrWhiteSpace(kvp.Value));
    }

    [Theory]
    [InlineData("en", "en")]
    [InlineData("ru", "ru")]
    [InlineData("fr", "fr")]
    [InlineData(null, null)] // system -> resolves to a supported code or english
    [InlineData("system", null)]
    [InlineData("zz", "en")] // unsupported -> english
    public void Resolve_MapsToSupportedLanguageOrEnglish(string? input, string? expectedExact)
    {
        var resolved = Localizer.Resolve(input);

        Assert.Contains(resolved, Localizer.SupportedLanguages);
        if (expectedExact is not null)
        {
            Assert.Equal(expectedExact, resolved);
        }
    }

    [Fact]
    public void Get_UnknownKey_ReturnsKeyItself()
    {
        Localizer.Instance.SetLanguage("en");
        Assert.Equal("this.key.does.not.exist", Localizer.Instance["this.key.does.not.exist"]);
    }

    [Fact]
    public void SetLanguage_SwitchesTranslations()
    {
        Localizer.Instance.SetLanguage("ru");
        Assert.Equal(Translations.Ru["Btn_Apply"], Localizer.Instance["Btn_Apply"]);

        Localizer.Instance.SetLanguage("en");
        Assert.Equal("Apply", Localizer.Instance["Btn_Apply"]);
    }
}
