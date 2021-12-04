namespace AdventOfCode2021.Day3;

public static class Problem
{
    public static IReadOnlyCollection<int[]> ParseInput(IEnumerable<string> inputLines)
    {
        return inputLines.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x =>
        {
            return x.Select(y => int.Parse(y.ToString())).ToArray();
        }).ToArray();
    }

    private static int IntArrayAsBinaryToInt(IReadOnlyList<int> binaryNum)
    {
        var counter = 0;
        var result = 0;
        for (var i = binaryNum.Count - 1; i >= 0; i--)
        {
            result += binaryNum[i] * (int)Math.Pow(2, counter);
            counter++;
        }

        return result;
    }

    private static async Task<IReadOnlyCollection<int[]>> GetInput()
    {
        return ParseInput(await File.ReadAllLinesAsync("Day3/Input.txt"));
    }

    private static int?[] GetMostCommonBits(IReadOnlyCollection<int[]> input)
    {
        var numLength = input.First().Length;
        var oneCounts = new int[numLength];
        
        foreach (var num in input)
        {
            for (var i = 0; i < numLength; i++)
            {
                if (num[i] == 1)
                {
                    oneCounts[i]++;
                }
            }
        }

        var mostCommonBits = new int?[numLength];

        for (var i = 0; i < numLength; i++)
        {
            if (input.Count % 2 == 0 && oneCounts[i] == input.Count / 2)
            {
                mostCommonBits[i] = null;
                continue;
            }
            mostCommonBits[i] = oneCounts[i] > input.Count / 2
                ? 1 : 0;
        }

        return mostCommonBits;
    }

    public static async Task<int> SolvePart1(IReadOnlyCollection<int[]>? input = null)
    {
        input ??= await GetInput();

        var mostCommonBits = GetMostCommonBits(input);
        var numLength = input.First().Length;

        var gamma = new int[numLength];
        var epsilon = new int[numLength];

        for (var i = 0; i < numLength; i++)
        {
            var mostCommonBit = mostCommonBits[i];
            gamma[i] = mostCommonBit == 1 ? 1 : 0;
            epsilon[i] = mostCommonBit == 1 ? 0 : 1;
        }

        var gammaInt = IntArrayAsBinaryToInt(gamma);
        var epsilonInt = IntArrayAsBinaryToInt(epsilon);
        
        return gammaInt * epsilonInt;
    }

    public static async Task<int> SolvePart2(IReadOnlyCollection<int[]>? input = null)
    {
        input ??= await GetInput();

        IReadOnlyCollection<int[]> GetMatchingOxygenNumbers(IReadOnlyCollection<int[]> oxygenInput, int position)
        {
            var mostCommonBits = GetMostCommonBits(oxygenInput);

            return oxygenInput.Where(num =>
                    (mostCommonBits[position] ?? 1) == num[position])
                .ToList();
        }
        
        IReadOnlyCollection<int[]> GetMatchingCo2Numbers(IReadOnlyCollection<int[]> co2Input, int position)
        {
            var mostCommonBits = GetMostCommonBits(co2Input);

            return co2Input.Where(num =>
                    (mostCommonBits[position] ?? 1) != num[position])
                .ToList();
        }

        var position = 0;

        var oxygenCheck = input;
        while (oxygenCheck.Count != 1)
        {
            oxygenCheck = GetMatchingOxygenNumbers(oxygenCheck, position);
            position++;
        }

        position = 0;
        var co2Check = input;
        while (co2Check.Count != 1)
        {
            co2Check = GetMatchingCo2Numbers(co2Check, position);
            position++;
        }

        return IntArrayAsBinaryToInt(oxygenCheck.First()) * IntArrayAsBinaryToInt(co2Check.First());
    }
}