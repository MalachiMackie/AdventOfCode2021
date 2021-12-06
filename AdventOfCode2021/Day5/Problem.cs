namespace AdventOfCode2021.Day5;

public static class Problem
{
    public static IReadOnlyCollection<(int, int, int, int)> ParseInput(IEnumerable<string> inputLines)
    {
        var coordinates = new List<(int, int, int, int)>();
        foreach (var line in inputLines)
        {
            var leftAndRight = line.Split(" -> ");
            var left = leftAndRight[0].Split(",");
            var right = leftAndRight[1].Split(",");
            coordinates.Add((int.Parse(left[0]), int.Parse(left[1]), int.Parse(right[0]), int.Parse(right[1])));
        }

        return coordinates;
    }

    private static async Task<IReadOnlyCollection<(int, int, int, int)>> GetInput()
    {
        return ParseInput(await File.ReadAllLinesAsync("Day5/input.txt"));
    }

    public static async Task<int> SolvePart1(IReadOnlyCollection<(int x1, int y1, int x2, int y2)>? lines = null)
    {
        lines ??= await GetInput();

        var points = new Dictionary<(int x, int y), int>();

        foreach (var (x1, y1, x2, y2) in lines)
        {
            if (x1 != x2 && y1 != y2)
                continue;

            var xDiff = 0;
            var yDiff = 0;

            if (x1 == x2) // vertical
            {
                yDiff = y1 < y2
                    ? 1
                    : -1;
            }
            else
            {
                xDiff = x1 < x2
                    ? 1
                    : -1;
            }

            var coord = (x: x1, y: y1);

            while (coord != (x2 + xDiff, y2 + yDiff))
            {
                if (!points.ContainsKey(coord))
                {
                    points.Add(coord, 0);
                }

                points[coord]++;
                coord = (coord.x + xDiff, coord.y + yDiff);
            }
        }

        return points.Count(x => x.Value >= 2);
    }

    public static async Task<int> SolvePart2(IReadOnlyCollection<(int x1, int y1, int x2, int y2)>? lines = null)
    {
        lines ??= await GetInput();

        var points = new Dictionary<(int x, int y), int>();

        foreach (var (x1, y1, x2, y2) in lines)
        {
            var xDiff = 0;
            var yDiff = 0;

            if (x1 != x2)
            {
                xDiff = x1 < x2
                    ? 1
                    : -1;
            }
            if (y1 != y2)
            {
                yDiff = y1 < y2
                    ? 1
                    : -1;
            }

            var coord = (x: x1, y: y1);

            while (coord != (x2 + xDiff, y2 + yDiff))
            {
                if (!points.ContainsKey(coord))
                {
                    points.Add(coord, 0);
                }

                points[coord]++;
                coord = (coord.x + xDiff, coord.y + yDiff);
            }
        }

        return points.Count(x => x.Value >= 2);
    }
}