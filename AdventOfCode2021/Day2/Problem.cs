namespace AdventOfCode2021.Day2;

public enum Direction
{
    Up,
    Down,
    Forward
}

public record Part1Position(int Horizontal, int Depth)
{
    public static Part1Position operator+(Part1Position position, Movement movement)
    {
        return movement.Direction switch
        {
            Direction.Forward => position with {Horizontal = position.Horizontal + movement.Magnitude},
            Direction.Up => position with {Depth = position.Depth - movement.Magnitude},
            Direction.Down => position with {Depth = position.Depth + movement.Magnitude},
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public record Part2Position(int Horizontal, int Depth, int Aim)
{
    public static Part2Position operator+(Part2Position position, Movement movement)
    {
        return movement.Direction switch
        {
            Direction.Forward => position with
            {
                Horizontal = position.Horizontal + movement.Magnitude,
                Depth = position.Depth + position.Aim * movement.Magnitude
            },
            Direction.Up => position with {Aim = position.Aim - movement.Magnitude},
            Direction.Down => position with {Aim = position.Aim + movement.Magnitude},
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public record Movement(Direction Direction, int Magnitude);

public static class Problem
{
    private static async Task<IEnumerable<Movement>> GetInput()
    {
        var textLines = await File.ReadAllLinesAsync("Day2/Input.txt");
        return ParseInput(textLines);
    }
    
    public static IEnumerable<Movement> ParseInput(IEnumerable<string> inputLines)
    {
        return inputLines.Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
            {
                var split = x.Split(" ");
                if (split.Length != 2)
                {
                    throw new InvalidOperationException();
                }

                var dir = DirectionFromString(split[0]);

                if (!int.TryParse(split[1], out var mag))
                {
                    throw new InvalidOperationException();
                }

                return new Movement(dir, mag);
            });
    }

    public static async Task<int> SolvePart1(IEnumerable<Movement>? plan = null)
    {
        plan ??= await GetInput();
        var (horizontal, depth) = plan.Aggregate(new Part1Position(0, 0), (current, movement) => current + movement);

        return depth * horizontal;
    }

    public static async Task<int> SolvePart2(IEnumerable<Movement>? plan = null)
    {
        plan ??= await GetInput();
        var (horizontal, depth, _) =
            plan.Aggregate(new Part2Position(0, 0, 0), (current, movement) => current + movement);

        return depth * horizontal;
    }
    
    private static Direction DirectionFromString(string str)
    {
        return str.ToLower() switch
        {
            "up" => Direction.Up,
            "down" => Direction.Down,
            "forward" => Direction.Forward,
            _ => throw new ArgumentOutOfRangeException(nameof(str))
        };
    }

    private static IEnumerable<Movement> ParsePlan(string plan)
    {
        return plan.Split("\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                var split = x.Split(" ");
                if (split.Length != 2)
                {
                    throw new InvalidOperationException();
                }

                var dir = DirectionFromString(split[0]);

                if (!int.TryParse(split[1], out var mag))
                {
                    throw new InvalidOperationException();
                }

                return new Movement(dir, mag);
            });
    }
}