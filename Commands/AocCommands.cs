using AOC.IO;
using AOC.Scaffolding;
using AOC.Solvers.Factories;
using Cocona;

namespace AOC.Commands;

public class AocCommands
{
    [Command("solve")]
    public static void Solve([Argument] int day, [Option] int? year = null)
    {
        year ??= DateTime.Now.Year;

        if (day < 1 || day > 25)
        {
            Console.WriteLine("Error: Day must be between 1 and 25.");
            return;
        }

        var solver = SolverFactory.GetSolver(day, year.Value);
        if (solver is null)
        {
            Console.WriteLine($"Error: No solver found for day {day} in year {year}.");
            return;
        }

        try
        {
            var input = InputReader.ReadInput(day, year.Value);

            var part1 = solver.SolvePart1(input);
            Console.WriteLine($"Day {day} Part 1: {part1}");

            try
            {
                var part2 = solver.SolvePart2(input);
                Console.WriteLine($"Day {day} Part 2: {part2}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"Day {day} Part 2: Not yet implemented.");
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    [Command("run-all")]
    public static void RunAll([Option] int? year = null)
    {
        year ??= DateTime.Now.Year;

        var days = SolverFactory.GetAvailableDays(year.Value);
        foreach (var day in days)
        {
            var solver = SolverFactory.GetSolver(day, year.Value);
            if (solver != null)
            {
                try
                {
                    var input = InputReader.ReadInput(day, year.Value);
                    var part1 = solver.SolvePart1(input);
                    var part2 = solver.SolvePart2(input);
                    Console.WriteLine($"Day {day} Part 1: {part1}");
                    Console.WriteLine($"Day {day} Part 2: {part2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error for day {day}: {ex.Message}");
                }
            }
        }
    }

    [Command("create")]
    public static async Task Create([Argument] int day, [Option] int? year = null)
    {
        year ??= DateTime.Now.Year;

        if (day < 1 || day > 25)
        {
            Console.WriteLine("Error: Day must be between 1 and 25.");
            return;
        }

        var existingSolver = SolverFactory.GetSolver(day, year.Value);
        if (existingSolver != null)
        {
            Console.Write("Day {day} in year {year} already exists. Overwrite? (y/n): ");
            var response = Console.ReadLine();
            if (response?.ToLower() != "y")
            {
                Console.WriteLine("Aborted.");
                return;
            }
        }

        var config = AppConfig.Load();

        if (string.IsNullOrEmpty(config.SessionCookie))
        {
            Console.WriteLine("Error: Session cookie not found.");
            Console.WriteLine("Set the AOC_SESSION environment variable or add 'SessionCookie' to config.json.");
            Console.WriteLine("To obtain the cookie: Log in to adventofcode.com, open browser dev tools, go to Application > Cookies, and copy the 'session' cookie value.");
            return;
        }

        var inputContent = await InputFetcher.FetchInput(day, year.Value, config);
        if (inputContent == null)
        {
            return; // Error already printed
        }

        var inputDir = Path.Combine("inputs", year.Value.ToString());
        Directory.CreateDirectory(inputDir);
        var inputPath = Path.Combine(inputDir, $"day{day}.txt");
        await File.WriteAllTextAsync(inputPath, inputContent);
        Console.WriteLine($"Fetched and saved input for day {day} in year {year}.");

        SolverScaffolder.CreateSolver(day, year.Value);
        Console.WriteLine($"Created solver class for day {day} in year {year}.");

        Console.WriteLine($"Scaffolded day {day} in year {year} successfully.");
    }
}
