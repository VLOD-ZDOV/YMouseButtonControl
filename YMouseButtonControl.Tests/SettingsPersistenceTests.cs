using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Commands.Settings;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings;
using YMouseButtonControl.Core.ViewModels.Dialogs.GlobalSettingsDialog.Queries.Settings.Models;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Covers the settings round-trip behind the Global Settings dialog. In particular the bool case
/// pins down the fix where <c>BoolSettingVm.Value</c> was a get-only property: a toggled
/// "Start Minimized" value must actually reach the database and read back.
/// </summary>
public class SettingsPersistenceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions<YMouseButtonControlDbContext> _options;

    public SettingsPersistenceTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        _options = new DbContextOptionsBuilder<YMouseButtonControlDbContext>()
            .UseSqlite(_connection)
            .Options;
        using var _ = NewContext(); // EnsureCreated seeds the settings rows.
    }

    private YMouseButtonControlDbContext NewContext() => new(_options);

    [Fact]
    public async Task BoolSetting_ToggledValuePersistsAndReadsBack()
    {
        await using var db = NewContext();
        var get = new GetBoolSetting.Handler(db);
        var update = new UpdateSetting<bool>.Handler(db);

        var before = get.Execute(new Query("StartMinimized"));
        Assert.False(before.Value); // seeded default

        // The VM's settable Value is what the checkbox binds to; flip it and save.
        before.Value = true;
        await update.ExecuteAsync(new UpdateSetting<bool>.Command("StartMinimized", before.Value));

        await using var verifyDb = NewContext();
        var after = new GetBoolSetting.Handler(verifyDb).Execute(new Query("StartMinimized"));
        Assert.True(after.Value);
    }

    [Fact]
    public async Task LanguageSetting_DefaultsToSystemAndPersists()
    {
        await using var db = NewContext();
        var get = new GetStringSetting.Handler(db);
        var update = new UpdateSetting<string>.Handler(db);

        Assert.Equal("system", get.Execute(new Query("Language")));

        await update.ExecuteAsync(new UpdateSetting<string>.Command("Language", "ru"));

        await using var verifyDb = NewContext();
        Assert.Equal("ru", new GetStringSetting.Handler(verifyDb).Execute(new Query("Language")));
    }

    public void Dispose() => _connection.Dispose();
}
