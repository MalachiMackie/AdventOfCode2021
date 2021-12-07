namespace AdventOfCode2021.Day7;

public static class Problem
{
    public static IEnumerable<int> ParseInput(string input)
    {
        return input.Split(",").Select(int.Parse);
    }

    private static async Task<IEnumerable<int>> GetInput()
    {
        return ParseInput(await File.ReadAllTextAsync("Day7/Input.txt"));
    }

    private static int GetMinFuelCost(IReadOnlyCollection<int> positions, Func<int, int> fuelCostFunc)
    {
        var (min, max) = GetMinAndMax(positions);

        var minFuel = int.MaxValue;

        for (var center = min; center <= max; center++)
        {
            var usedFuel = 0;
            foreach (var num in positions)
            {
                usedFuel += fuelCostFunc(Math.Abs(num - center));
                if (usedFuel > minFuel)
                    break;
            }

            if (usedFuel >= minFuel) continue;
            
            minFuel = usedFuel;
        }

        return minFuel;
    }
    
    public static async Task<int> SolvePart1(IEnumerable<int>? input = null)
    {
        input ??= await GetInput();

        var positions = input.ToArray();

        var minFuelCost = GetMinFuelCost(positions, dist => dist);

        return minFuelCost;
    }
    
    
    public static async Task<int> SolvePart2(IEnumerable<int>? input = null)
    {
        input ??= await GetInput();

        var positions = input.ToArray();

        var minFuelCost = GetMinFuelCost(positions, dist => dist * (dist + 1) / 2);

        return minFuelCost;
    }

    private static (int min, int max) GetMinAndMax(IEnumerable<int> numbers)
    {
        var min = int.MaxValue;
        var max = int.MinValue;
        
        foreach (var pos in numbers)
        {
            if (pos < min)
                min = pos;

            if (pos > max)
                max = pos;
        }

        return (min, max);
    }
}