using System.Text.Json;

namespace AOC.Scaffolding;

public class AppConfig
{
    public string? SessionCookie { get; set; }

    public static AppConfig Load()
    {
        var config = new AppConfig { };

        var configPath = "config.json";
        if (File.Exists(configPath))
        {
            try
            {
                var json = JsonDocument.Parse(File.ReadAllText(configPath));
                var root = json.RootElement;

                if (root.TryGetProperty("SessionCookie", out var cookie))
                    config.SessionCookie = cookie.GetString();
            }
            catch
            {
                // Ignore parse errors
            }
        }

        // Override session with env var if set
        var envSession = Environment.GetEnvironmentVariable("AOC_SESSION");
        if (!string.IsNullOrEmpty(envSession))
            config.SessionCookie = envSession;

        return config;
    }
}
