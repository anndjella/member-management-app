using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Xunit;

public class DbTests
{
    private static string MasterConnStr
        => Environment.GetEnvironmentVariable("TEST_SQL_CONNSTR_MASTER");

    [Fact, Trait("TestCategory", "Integration")]
    public async Task SimpleRoundtrip()
    {
        Assert.False(string.IsNullOrWhiteSpace(MasterConnStr),
            "TEST_SQL_CONNSTR_MASTER env var nije postavljen.");

        var masterBuilder = new SqlConnectionStringBuilder(MasterConnStr);
        if (masterBuilder.ConnectTimeout < 60) masterBuilder.ConnectTimeout = 60;

        await using (var master = new SqlConnection(masterBuilder.ConnectionString))
        {
            await master.OpenAsync();

            await using var cmd = master.CreateCommand();
            cmd.CommandText = @"
IF DB_ID('AppTestDb') IS NULL
    CREATE DATABASE AppTestDb;";
            await cmd.ExecuteNonQueryAsync();
        }

        var dbBuilder = new SqlConnectionStringBuilder(masterBuilder.ConnectionString)
        {
            InitialCatalog = "AppTestDb"
        };

        await using (var db = new SqlConnection(dbBuilder.ConnectionString))
        {
            await db.OpenAsync();

            await using (var drop = db.CreateCommand())
            {
                drop.CommandText = @"IF OBJECT_ID('dbo.Users','U') IS NOT NULL DROP TABLE dbo.Users;";
                await drop.ExecuteNonQueryAsync();
            }

            await using (var create = db.CreateCommand())
            {
                create.CommandText = @"CREATE TABLE dbo.Users(Id INT PRIMARY KEY, Name NVARCHAR(50) NOT NULL);";
                await create.ExecuteNonQueryAsync();
            }

            await using (var insert = db.CreateCommand())
            {
                insert.CommandText = @"INSERT INTO dbo.Users(Id, Name) VALUES (1, N'Ana');";
                await insert.ExecuteNonQueryAsync();
            }

            await using (var count = db.CreateCommand())
            {
                count.CommandText = @"SELECT COUNT(*) FROM dbo.Users;";
                var n = (int)await count.ExecuteScalarAsync();
                Assert.Equal(1, n);
            }
        }
    }
}
