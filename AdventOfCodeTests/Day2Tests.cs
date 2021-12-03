using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day2Tests
{
    private const string Input = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
    
    [Fact]
    public async Task Part1Test()
    {
        var plan = AdventOfCode2021.Day2.Problem.ParseInput(Input.Split("\n"));
        var output = await AdventOfCode2021.Day2.Problem.SolvePart1(plan);
        output.Should().Be(150);
    }

    [Fact]
    public async Task Part2Test()
    {
        var plan = AdventOfCode2021.Day2.Problem.ParseInput(Input.Split("\n"));
        var output = await AdventOfCode2021.Day2.Problem.SolvePart2(plan);
        output.Should().Be(900);
    }
}