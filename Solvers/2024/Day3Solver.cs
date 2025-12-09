using System.Text.RegularExpressions;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y2024
{
    public class Day3Solver : IPuzzleSolver
    {
        private Regex mulInstruction = new Regex(@"mul\((\d+),(\d+)\)");

        public string SolvePart1(List<string> input)
        {
            int result = 0;
            foreach (var line in input)
            {
                var matches = mulInstruction.Matches(line);
                foreach (Match match in matches)
                {
                    int a = int.Parse(match.Groups[1].Value);
                    int b = int.Parse(match.Groups[2].Value);
                    result += a * b;
                }
            }

            return result.ToString();
        }

        public string SolvePart2(List<string> input)
        {
            var data = string.Join("\n", input);
            // remove everything between don't() to do()
            var cleaned = Regex.Replace(data, @"don't\([\s\S]*?do\(\)", "", RegexOptions.Multiline);

            var matches = mulInstruction.Matches(cleaned);
            int result = 0;
            foreach (Match match in matches)
            {
                int a = int.Parse(match.Groups[1].Value);
                int b = int.Parse(match.Groups[2].Value);
                result += a * b;
            }

            return result.ToString();
        }
    }
}
