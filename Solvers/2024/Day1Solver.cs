using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AOC.Solvers.Interfaces;

namespace AOC.Solvers.Y2024
{
    public class Day1Solver : IPuzzleSolver
{
    public string SolvePart1(List<string> input)
    {
        var left = new List<int>();
        var right = new List<int>();

        input.Select(i => Regex.Split(i, "\\s+"))
            .ToList()
            .ForEach(p =>
            {
                left.Add(int.Parse(p[0]));
                right.Add(int.Parse(p[1]));
            });

        left.Sort();
        right.Sort();

        var mix = left.Zip(right, (l, r) => Math.Max(l, r) - Math.Min(l, r)).ToList();

        return mix.Sum().ToString();
    }

    public string SolvePart2(List<string> input)
    {
        var left = new List<int>();
        var right = new List<int>();

        input.Select(i => Regex.Split(i, "\\s+"))
            .ToList()
            .ForEach(p =>
            {
                left.Add(int.Parse(p[0]));
                right.Add(int.Parse(p[1]));
            });

        // var leftFreq = GetFrequencyMap(left);
        var rightFreq = GetFrequencyMap(right);

        var result = 0;

        foreach (var v in left)
        {
            if (rightFreq.ContainsKey(v))
            {
                result += v * rightFreq[v];
            }
        }
        return result.ToString();
    }

    private Dictionary<int, int> GetFrequencyMap(List<int> numbers)
    {
        var frequencyMap = new Dictionary<int, int>();
        foreach (var number in numbers)
        {
            if (frequencyMap.ContainsKey(number))
            {
                frequencyMap[number]++;
            }
            else
            {
                frequencyMap[number] = 1;
            }
        }
        return frequencyMap;
    }
}
}
