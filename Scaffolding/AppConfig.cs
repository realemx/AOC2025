using System.Text.Json;

namespace AOC.Scaffolding;

public class AppConfig
{
    public string? SessionCookie { get; set; }
    public int Year { get; set; }

    public static AppConfig Load()
    {
        var config = new AppConfig
        {
            Year = DateTime.Now.Month >= 12 ? DateTime.Now.Year : DateTime.Now.Year - 1
        };

        var configPath = "config.json";
        if (File.Exists(configPath))
        {
            try
            {
                var json = JsonDocument.Parse(File.ReadAllText(configPath));
                var root = json.RootElement;

                if (root.TryGetProperty("SessionCookie", out var cookie))
                    config.SessionCookie = cookie.GetString();

                if (root.TryGetProperty("Year", out var year))
                    config.Year = year.GetInt32();
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
