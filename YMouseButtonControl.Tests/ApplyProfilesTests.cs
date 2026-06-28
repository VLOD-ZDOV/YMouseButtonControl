using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using YMouseButtonControl.Core.Services.Profiles;
using YMouseButtonControl.Core.Services.Profiles.Queries.Profiles;
using YMouseButtonControl.Core.ViewModels.MainWindow.Commands.Profiles;
using YMouseButtonControl.Core.ViewModels.Models;
using YMouseButtonControl.Domain.Models;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Characterization tests for <see cref="ApplyProfiles"/> — they pin down that the Apply/save
/// path actually persists edits to the built-in "Default" profile (button-mapping selection and
/// the <c>Checked</c> flag).
///
/// Note: these pass on both the old <c>List.ForEach(async ...)</c> implementation and the awaited
/// <c>foreach</c> version, because the SQLite provider runs EF Core "async" calls synchronously,
/// so the fire-and-forget continuations complete inline. They therefore do NOT reproduce the
/// reported persistence bug (#41/#35); the more likely root cause of that is the database file
/// resolving to a different path depending on the working directory — see
/// <see cref="DatabasePathTests"/>.
///
/// Each test uses a real SQLite database (in-memory, shared connection) so the seeded "Default"
/// profile and its button mappings behave exactly like production.
/// </summary>
public class ApplyProfilesTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions<YMouseButtonControlDbContext> _options;

    public ApplyProfilesTests()
    {
        // A shared, open in-memory connection keeps the schema + seed data alive for the
        // lifetime of the test while still letting us open several independent DbContexts.
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        _options = new DbContextOptionsBuilder<YMouseButtonControlDbContext>()
            .UseSqlite(_connection)
            .Options;

        // Constructor calls Database.EnsureCreated(), which creates the schema and seed data.
        using var _ = NewContext();
    }

    private YMouseButtonControlDbContext NewContext() => new(_options);

    [Fact]
    public async Task ExecuteAsync_PersistsButtonMappingSelectionChange_OnExistingProfile()
    {
        // Arrange: load the seeded Default profile into the cache, exactly like the app does.
        await using var db = NewContext();
        var cache = new ProfilesCache(new ListDbProfiles.Handler(db));
        var profile = cache.Profiles.Single();

        // Simulate the user switching Mouse Button 4 from "No Change" to "Simulated Keystroke".
        var nothingMb4 = profile.ButtonMappings.Single(b =>
            b is NothingMappingVm && b.MouseButton == MouseButton.Mb4
        );
        var simMb4 = profile.ButtonMappings.Single(b =>
            b is SimulatedKeystrokeVm && b.MouseButton == MouseButton.Mb4
        );
        nothingMb4.Selected = false;
        simMb4.Selected = true;

        // Act
        await new ApplyProfiles.Handler(db, cache).ExecuteAsync();

        // Assert: read the database back through a fresh context.
        await using var verifyDb = NewContext();
        var mb4 = verifyDb
            .ButtonMappings.AsNoTracking()
            .Where(b => b.ProfileId == profile.Id && b.MouseButton == MouseButton.Mb4)
            .ToList();

        Assert.True(mb4.Single(b => b is SimulatedKeystroke).Selected);
        Assert.False(mb4.Single(b => b is NothingMapping).Selected);
    }

    [Fact]
    public async Task ExecuteAsync_PersistsCheckedToggle_OnExistingProfile()
    {
        // Arrange
        await using var db = NewContext();
        var cache = new ProfilesCache(new ListDbProfiles.Handler(db));
        var profile = cache.Profiles.Single();
        Assert.True(profile.Checked); // seeded as checked

        // Act: user unchecks the profile.
        profile.Checked = false;
        await new ApplyProfiles.Handler(db, cache).ExecuteAsync();

        // Assert
        await using var verifyDb = NewContext();
        var saved = verifyDb.Profiles.AsNoTracking().Single(p => p.Id == profile.Id);
        Assert.False(saved.Checked);
    }

    public void Dispose() => _connection.Dispose();
}
