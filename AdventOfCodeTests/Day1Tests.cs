using System.Threading.Tasks;
using AdventOfCode2021.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day1Tests
{
    private static readonly int[] TestInput =
    {
        199,
        200,
        208,
        210,
        200,
        207,
        240,
        269,
        260,
        263
    };
    
    [Fact]
    public async Task Part1Test()
    {
        var output = await Problem.SolvePart1(TestInput);
        output.Should().Be(7);
    }

    [Fact]
    public async Task Part2Test()
    {
        var output = await Problem.SolvePart2(TestInput);
        output.Should().Be(5);
    }
}