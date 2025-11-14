using AOC.IO;
using Cocona;
using AOC.Solvers.Factories;

var app = CoconaApp.Create();

app.AddCommand(([Option('d')]int day) =>
{
    if (day < 1 || day > 25)
    {
        Console.WriteLine("Error: Day must be between 1 and 25.");
        return;
    }

    var solver = SolverFactory.GetSolver(day);
    if (solver is null)
    {
        Console.WriteLine($"Error: No solver found for day {day}.");
        return;
    }

    try
    {
        var input = InputReader.ReadInput(day);

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
}).WithDescription("Run the solution for a specific day.");

app.AddCommand("run-all", () =>
{
    var days = SolverFactory.GetAvailableDays();
    foreach (var day in days)
    {
        var solver = SolverFactory.GetSolver(day);
        if (solver != null)
        {
            try
            {
                var input = InputReader.ReadInput(day);
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
}).WithDescription("Run solutions for all available days.");

app.Run();
