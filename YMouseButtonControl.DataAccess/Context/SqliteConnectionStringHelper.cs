using Microsoft.Data.Sqlite;

namespace YMouseButtonControl.Infrastructure.Context;

public static class SqliteConnectionStringHelper
{
    /// <summary>
    /// Rebases a relative SQLite <c>Data Source</c> onto an absolute directory so the database
    /// location does not depend on the process' current working directory.
    /// </summary>
    /// <remarks>
    /// A relative <c>Data Source</c> is otherwise resolved against
    /// <see cref="System.Environment.CurrentDirectory"/>, which differs between a normal launch
    /// and an autostart launch. That made profile changes appear not to persist
    /// (issues #41, #35, #32). In-memory sources are left untouched.
    /// </remarks>
    public static string ToAbsolute(string? connectionString, string baseDirectory)
    {
        var builder = new SqliteConnectionStringBuilder(
            string.IsNullOrWhiteSpace(connectionString)
                ? "Data Source=YMouseButtonControl.db"
                : connectionString
        );

        var dataSource = builder.DataSource;
        if (
            !string.IsNullOrEmpty(dataSource)
            && !dataSource.Equals(":memory:", System.StringComparison.Ordinal)
            && !Path.IsPathRooted(dataSource)
        )
        {
            builder.DataSource = Path.Combine(baseDirectory, dataSource);
        }

        return builder.ConnectionString;
    }
}
