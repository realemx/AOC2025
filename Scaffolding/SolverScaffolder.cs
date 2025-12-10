namespace AOC.Scaffolding;

public static class SolverScaffolder
{
    public static void CreateSolver(int day, int year)
    {
        var className = $"Day{day}Solver";
        var dir = $"Solvers/{year}";
        Directory.CreateDirectory(dir);
        var path = $"{dir}/{className}.cs";
        var content = $@"
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y{year};

public class {className} : IPuzzleSolver
{{
    public string SolvePart1(List<string> input)
    {{
        // Parse input and implement logic
        return ""Not implemented yet"";
    }}

    public string SolvePart2(List<string> input)
    {{
        throw new NotImplementedException();
    }}
}}
";
        File.WriteAllText(path, content);
    }
}
