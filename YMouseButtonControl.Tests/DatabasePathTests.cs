using System;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using YMouseButtonControl.Infrastructure.Context;

namespace YMouseButtonControl.Tests;

/// <summary>
/// Tests for <see cref="SqliteConnectionStringHelper"/>, which guards against the persistence
/// problem behind issues #41 ("saving profiles doesn't work"), #35 ("profile active when
/// unchecked") and #32 ("working directory incorrect at startup").
///
/// Root cause: the connection string in appsettings.json is <c>Data Source=YMouseButtonControl.db</c>
/// — a relative path. A relative SQLite data source is resolved against the process' current
/// working directory, which differs between a normal launch and an autostart launch, so the app
/// would read/write a different database file each time and changes appeared not to persist.
/// </summary>
public class DatabasePathTests
{
    private const string RelativeConnectionString = "Data Source=YMouseButtonControl.db";

    [Fact]
    public void RelativeDataSource_ResolvesToDifferentFiles_PerBaseDirectory()
    {
        // This is the bug: the same relative connection string points at a different physical
        // file depending on the base directory (the working directory at launch time).
        var fromDirA = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute(
                RelativeConnectionString,
                Path.Combine(Path.GetTempPath(), "ymbc-dir-a")
            )
        ).DataSource;

        var fromDirB = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute(
                RelativeConnectionString,
                Path.Combine(Path.GetTempPath(), "ymbc-dir-b")
            )
        ).DataSource;

        Assert.NotEqual(fromDirA, fromDirB);
    }

    [Fact]
    public void ToAbsolute_RebasesRelativeSource_OntoGivenDirectory()
    {
        var dataDirectory = Path.Combine(Path.GetTempPath(), "ymbc-data");

        var result = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute(RelativeConnectionString, dataDirectory)
        ).DataSource;

        Assert.True(Path.IsPathRooted(result));
        Assert.Equal(Path.Combine(dataDirectory, "YMouseButtonControl.db"), result);
    }

    [Fact]
    public void ToAbsolute_LeavesAbsoluteSource_Unchanged()
    {
        var absolute = Path.Combine(Path.GetTempPath(), "already-absolute.db");

        var result = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute($"Data Source={absolute}", "/some/other/dir")
        ).DataSource;

        Assert.Equal(absolute, result);
    }

    [Fact]
    public void ToAbsolute_LeavesInMemorySource_Unchanged()
    {
        var result = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute("Data Source=:memory:", "/some/dir")
        ).DataSource;

        Assert.Equal(":memory:", result);
    }

    [Fact]
    public void ToAbsolute_NullOrEmpty_FallsBackToDefaultFileName()
    {
        var dataDirectory = Path.Combine(Path.GetTempPath(), "ymbc-default");

        var result = new SqliteConnectionStringBuilder(
            SqliteConnectionStringHelper.ToAbsolute(null, dataDirectory)
        ).DataSource;

        Assert.Equal(Path.Combine(dataDirectory, "YMouseButtonControl.db"), result);
    }

    [Fact]
    public void DbContext_WithRebasedConnectionString_CreatesFileAndPersistsAcrossLaunches()
    {
        var dataDirectory = Path.Combine(
            Path.GetTempPath(),
            "ymbc-e2e-" + Guid.NewGuid().ToString("N")
        );
        Directory.CreateDirectory(dataDirectory);
        try
        {
            var connectionString = SqliteConnectionStringHelper.ToAbsolute(
                RelativeConnectionString,
                dataDirectory
            );
            var expectedFile = Path.Combine(dataDirectory, "YMouseButtonControl.db");
            var options = new DbContextOptionsBuilder<YMouseButtonControlDbContext>()
                .UseSqlite(connectionString)
                .Options;

            // First "launch": the database is created and the user unchecks the Default profile.
            using (var db = new YMouseButtonControlDbContext(options))
            {
                var profile = db.Profiles.Single();
                profile.Checked = false;
                db.SaveChanges();
            }

            Assert.True(File.Exists(expectedFile));

            // Second "launch" from the same absolute path sees the persisted change.
            using (var db = new YMouseButtonControlDbContext(options))
            {
                Assert.False(db.Profiles.Single().Checked);
            }
        }
        finally
        {
            SqliteConnection.ClearAllPools();
            Directory.Delete(dataDirectory, recursive: true);
        }
    }
}
