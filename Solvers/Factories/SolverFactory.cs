using System.Reflection;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Factories;

public static class SolverFactory
{
    private static readonly Dictionary<string, Type> _solvers = new();

    static SolverFactory()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var solverTypes = assembly.GetTypes()
            .Where(t => typeof(IPuzzleSolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Where(t => t.Name.StartsWith("Day") && t.Name.EndsWith("Solver"))
            .ToList();

        foreach (var type in solverTypes)
        {
            // Assume namespace like AOC.Solvers.Y2024
            var nsParts = type.Namespace?.Split('.');
            if (nsParts != null && nsParts.Length >= 3 && nsParts[0] == "AOC" && nsParts[1] == "Solvers" && nsParts[2].StartsWith("Y") && int.TryParse(nsParts[2].Substring(1), out int year))
            {
                var dayPart = type.Name.Substring(3, type.Name.Length - 9); // Remove "Day" and "Solver"
                if (int.TryParse(dayPart, out int day))
                {
                    var key = $"{year}_{day}";
                    _solvers[key] = type;
                }
            }
        }
    }

    public static IPuzzleSolver? GetSolver(int day, int year)
    {
        var key = $"{year}_{day}";
        if (_solvers.TryGetValue(key, out var type))
        {
            return (IPuzzleSolver)Activator.CreateInstance(type)!;
        }
        return null;
    }

    public static IEnumerable<int> GetAvailableDays(int year)
    {
        return _solvers.Keys.Where(k => k.StartsWith($"{year}_")).Select(k => int.Parse(k.Split('_')[1])).OrderBy(d => d);
    }
}
