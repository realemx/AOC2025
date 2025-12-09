using System.IO;

namespace AOC.IO;

public static class InputReader
{
    private const string InputDirectory = "./inputs/";

    public static List<string> ReadInput(int day, int year)
    {
        string filePath = Path.Combine(InputDirectory, year.ToString(), $"day{day}.txt");
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Input file not found: {filePath}");
            }
            return File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading input for day {day} in year {year}: {ex.Message}");
        }
    }
}
