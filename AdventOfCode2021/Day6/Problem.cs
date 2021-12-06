using System.Collections.Concurrent;

namespace AdventOfCode2021.Day6;

public static class Problem
{
    public static IEnumerable<int> ParseInput(string input)
    {
        return input.Split(",").Select(int.Parse);
    }

    private static async Task<IEnumerable<int>> GetInput()
    {
        return ParseInput(await File.ReadAllTextAsync("Day6/Input.txt"));
    }

    private static long FindFishCountAfterDays(IEnumerable<int> initialFish, int days)
    {
        var ageCounts = new Dictionary<int, long>
        {
            {0,0},
            {1,0},
            {2,0},
            {3,0},
            {4,0},
            {5,0},
            {6,0},
            {7,0},
            {8,0},
        };

        foreach (var fish in initialFish)
        {
            ageCounts[fish]++;
        }

        for (var day = 0; day < days; day++)
        {
            var newFish = ageCounts[0];
            var resetFish = ageCounts[0];
            ageCounts[0] = ageCounts[1];
            ageCounts[1] = ageCounts[2];
            ageCounts[2] = ageCounts[3];
            ageCounts[3] = ageCounts[4];
            ageCounts[4] = ageCounts[5];
            ageCounts[5] = ageCounts[6];
            ageCounts[6] = ageCounts[7] + resetFish;
            ageCounts[7] = ageCounts[8];
            ageCounts[8] = newFish;
        }

        return ageCounts.Values.Aggregate(0L, (a, b) => a + b);
    }

    public static async Task<int> SolvePart1(IEnumerable<int>? input = null)
    {
        var fishList = (input ?? await GetInput()).ToList();

        return (int)FindFishCountAfterDays(fishList, 80);
    }

    public static async Task<long> SolvePart2(IEnumerable<int>? input = null)
    {
        var fishList = input ?? await GetInput();

        return FindFishCountAfterDays(fishList, 256);
    }
}