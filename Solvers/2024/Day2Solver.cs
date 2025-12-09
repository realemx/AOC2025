using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y2024
{
    public class Day2Solver : IPuzzleSolver
    {
        record Report(List<int> Levels);

        public string SolvePart1(List<string> input)
        {
            var reports = input.Select(line => new Report(line.Split(' ').Select(int.Parse).ToList())).ToList();

            int safeCount = reports.Count(IsSafe);

            return safeCount.ToString();
        }

        public string SolvePart2(List<string> input)
        {
            var reports = input.Select(line => new Report(line.Split(' ').Select(int.Parse).ToList())).ToList();

            int safeCount = 0;
            foreach (var report in reports)
            {
                if (IsSafe(report))
                {
                    safeCount++;
                    continue;
                }

                // Try removing one level to see if it becomes safe
                for (int i = 0; i < report.Levels.Count; i++)
                {
                    var modifiedLevels = new List<int>(report.Levels);
                    modifiedLevels.RemoveAt(i);
                    var modifiedReport = new Report(modifiedLevels);
                    if (IsSafe(modifiedReport))
                    {
                        safeCount++;
                        break;
                    }
                }
            }

            return safeCount.ToString();
        }

        private bool IsOnlySlightlyIncreasing(Report report)
        {
            for (int i = 1; i < report.Levels.Count; i++)
            {
                var diff = report.Levels[i] - report.Levels[i - 1];
                if (diff > 0 || diff == 0 || diff < -3)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsOnlySlightlyDecreasing(Report report)
        {
            for (int i = 1; i < report.Levels.Count; i++)
            {
                var diff = report.Levels[i] - report.Levels[i - 1];
                if (diff < 0 || diff == 0 || diff > 3)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSafe(Report report)
        {
            return IsOnlySlightlyIncreasing(report) || IsOnlySlightlyDecreasing(report);
        }
    }

}
