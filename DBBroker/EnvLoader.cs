using System;
using System.IO;

public static class EnvLoader
{
    public static void Load(string fileName = ".env")
    {
        var envPath = FindClosestEnvPath(fileName);
        if (envPath == null) return;

        foreach (var raw in File.ReadAllLines(envPath))
        {
            var line = raw.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.StartsWith("#")) continue;

            var parts = line.Split(new[] { '=' }, 2, StringSplitOptions.None);
            if (parts.Length != 2) continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim();

            if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
                value = value.Substring(1, value.Length - 2);

            Environment.SetEnvironmentVariable(key, value);
        }
    }


    private static string FindClosestEnvPath(string fileName)
    {
        var cur = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        while (cur != null)
        {
            var candidate = Path.Combine(cur.FullName, fileName);
            if (File.Exists(candidate)) return candidate;
            cur = cur.Parent;
        }
        return null;
    }
}
