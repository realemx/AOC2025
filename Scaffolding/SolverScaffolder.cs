namespace AOC.Scaffolding;

public static class SolverScaffolder
{
    public static void CreateSolver(int day)
    {
        var className = $"Day{day}Solver";
        var path = $"Solvers/{className}.cs";
        var content = $@"
using AOC.Solvers.Interfaces;

namespace AOC.Solvers
{{
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
}}
";
        File.WriteAllText(path, content);
    }
}
