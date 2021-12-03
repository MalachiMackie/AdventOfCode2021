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
    public void Part1Test()
    {
        Problem.SolvePart1(TestInput).Should().Be(7);
    }

    [Fact]
    public void Part2Test()
    {
        Problem.SolvePart2(TestInput).Should().Be(5);
    }
}