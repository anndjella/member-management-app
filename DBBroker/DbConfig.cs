using System;
using System.Configuration;

public static class DbConfig
{
    public static string ConnectionString()
    {
        var pass = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
        var db = Environment.GetEnvironmentVariable("DB_NAME") ?? "FitnessStudioDB";
        var user = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";

        if (!string.IsNullOrWhiteSpace(pass))
            return $"Server={host},{port};Database={db};User Id={user};Password={pass};TrustServerCertificate=True;";

        var cs = ConfigurationManager.ConnectionStrings["baza"]?.ConnectionString;

        return "bLA";
    }
}
