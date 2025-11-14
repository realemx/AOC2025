using System.Text.Json;

namespace AOC.Scaffolding;

public static class CredentialsProvider
{
    public static string? GetSessionCookie()
    {
        var session = Environment.GetEnvironmentVariable("AOC_SESSION");
        if (!string.IsNullOrEmpty(session)) return session;

        var configPath = "config.json";
        if (File.Exists(configPath))
        {
            try
            {
                var config = JsonDocument.Parse(File.ReadAllText(configPath));
                if (config.RootElement.TryGetProperty("SessionCookie", out var cookie))
                {
                    return cookie.GetString();
                }
            }
            catch
            {
                // Ignore parse errors
            }
        }
        return null;
    }
}
