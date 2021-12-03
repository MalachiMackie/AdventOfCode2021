namespace AdventOfCode2021.Day1;

public static class Problem
{

    private static async Task<int[]> GetInput()
    {
        var text = await File.ReadAllLinesAsync("Day1/Input.txt");
        return text.Select(x => int.TryParse(x, out var value)
            ? value
            : throw new InvalidOperationException("Input was not in correct format"))
            .ToArray();
    }

    public static async Task<int> SolvePart1(IEnumerable<int>? inputValues = null)
    {
        var counter = 0;
        var prev = (int?)null;

        inputValues ??= await GetInput();

        foreach (var input in inputValues)
        {
            if (input > prev)
            {
                counter++;
            }

            prev = input;
        }

        return counter;
    }
    
    public static async Task<int> SolvePart2(IEnumerable<int>? inputValues = null)
    {
        int GetSum(IEnumerable<int> numbers)
        {
            return numbers.Aggregate((curr, prev) => curr + prev);
        }

        inputValues ??= await GetInput();

        var completeWindows = new List<List<int>>();
        var windows = new List<List<int>>();

        foreach (var value in inputValues)
        {
            windows.Add(new List<int>());
            foreach (var window in windows.ToArray())
            {
                window.Add(value);
                if (window.Count != 3) continue;
                
                completeWindows.Add(window);
                windows.Remove(window);
            }
        }

        int? previousSum = null;
        var counter = 0;

        foreach (var sum in completeWindows.Select(GetSum))
        {
            if (sum > previousSum)
            {
                counter++;
            }

            previousSum = sum;
        }

        return counter;
    }
}