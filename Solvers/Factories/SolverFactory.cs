using System.Reflection;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Factories;

public static class SolverFactory
{
    private static readonly Dictionary<int, Type> _solvers = new();

    static SolverFactory()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var solverTypes = assembly.GetTypes()
            .Where(t => typeof(IPuzzleSolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Where(t => t.Name.StartsWith("Day") && t.Name.EndsWith("Solver"))
            .ToList();

        foreach (var type in solverTypes)
        {
            var dayPart = type.Name.Substring(3, type.Name.Length - 9); // Remove "Day" and "Solver"
            if (int.TryParse(dayPart, out int day))
            {
                _solvers[day] = type;
            }
        }
    }

    public static IPuzzleSolver? GetSolver(int day)
    {
        if (_solvers.TryGetValue(day, out var type))
        {
            return (IPuzzleSolver)Activator.CreateInstance(type)!;
        }
        return null;
    }

    public static IEnumerable<int> GetAvailableDays()
    {
        return _solvers.Keys.OrderBy(d => d);
    }
}
