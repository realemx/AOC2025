
using System.Text.RegularExpressions;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y2025
{
    public class Day1Solver : IPuzzleSolver
    {
        private record Rotation(Direction Turn, long Distance);
        private enum Direction { Right, Left };


        private IEnumerable<Rotation> ParseInput(List<string> input)
        {
            Regex r = new Regex(@"([RL])(\d+)");
            foreach (var line in input)
            {
                var match = r.Match(line);
                if (match.Success)
                {
                    var turn = match.Groups[1].Value[0];
                    var distance = long.Parse(match.Groups[2].Value);
                    yield return new Rotation(turn == 'R' ? Direction.Right : Direction.Left, distance);
                }
            }
        }

        public string SolvePart1(List<string> input)
        {
            var rotations = ParseInput(input);

            long wheel = 50;
            long result = 0;

            foreach (var rotation in rotations)
            {
                wheel += (rotation.Turn == Direction.Right ? 1 : -1) * rotation.Distance;
                if (wheel >= 100) wheel = wheel % 100;
                while (wheel < 0) wheel += 100;
                if (wheel == 0) result += 1;
            }

            // Process instructions and implement logic
            return result.ToString();
        }

        public string SolvePart2(List<string> input)
        {
            var rotations = ParseInput(input);

            long wheel = 50;
            long result = 0;

            foreach (var rotation in rotations)
            {
                var rot = rotation.Turn == Direction.Right ? 1 : -1;

                for (long i = 0; i < rotation.Distance; i++)
                {
                    wheel += rot;
                    if (wheel >= 100) wheel = wheel % 100;
                    while (wheel < 0) wheel += 100;
                    if (wheel == 0) result += 1;
                }
            }

            return result.ToString();
        }
    }
}
