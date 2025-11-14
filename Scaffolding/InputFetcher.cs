namespace AOC.Scaffolding;

public static class InputFetcher
{
    public static async Task<string?> FetchInput(int day, AppConfig config)
    {
        var url = $"https://adventofcode.com/{config.Year}/day/{day}/input";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cookie", $"session={config.SessionCookie}");

        try
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Error: Day {day} not unlocked yet or invalid day.");
                }
                else
                {
                    Console.WriteLine($"Error fetching input: {response.StatusCode} - {response.ReasonPhrase}");
                }
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching input: {ex.Message}");
            return null;
        }
    }
}
