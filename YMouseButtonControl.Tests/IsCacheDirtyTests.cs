using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using YMouseButtonControl.Core.Services.Profiles;
using YMouseButtonControl.Core.Services.Profiles.Queries.Profiles;
using YMouseButtonControl.Core.ViewModels.MainWindow.Queries.Profiles;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Tests for <see cref="IsCacheDirty"/>. The handler decides whether the in-memory profile cache
/// differs from what is persisted (which gates the "Apply" button). Previously it compared the
/// cache against a database projection that omitted the button mappings, so it reported "dirty"
/// even when nothing had changed.
/// </summary>
public class IsCacheDirtyTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions<YMouseButtonControlDbContext> _options;

    public IsCacheDirtyTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        _options = new DbContextOptionsBuilder<YMouseButtonControlDbContext>()
            .UseSqlite(_connection)
            .Options;
        using var _ = NewContext();
    }

    private YMouseButtonControlDbContext NewContext() => new(_options);

    [Fact]
    public void Execute_ReturnsFalse_WhenCacheMatchesDatabase()
    {
        using var db = NewContext();
        var cache = new ProfilesCache(new ListDbProfiles.Handler(db));

        // Freshly loaded cache equals what is in the database -> not dirty.
        Assert.False(new IsCacheDirty.Handler(cache, db).Execute());
    }

    [Fact]
    public void Execute_ReturnsTrue_WhenACacheProfileWasEdited()
    {
        using var db = NewContext();
        var cache = new ProfilesCache(new ListDbProfiles.Handler(db));

        // Edit a profile in the cache only (not yet saved) -> dirty.
        cache.Profiles.Single().Checked = false;

        Assert.True(new IsCacheDirty.Handler(cache, db).Execute());
    }

    public void Dispose() => _connection.Dispose();
}
