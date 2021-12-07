using System;
using System.Threading.Tasks;
using AdventOfCode2021.Day3;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day3Tests
{
    private static readonly string Input = @"
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010
";
    
    [Fact]
    public async Task Part1Test()
    {
        var input = Problem.ParseInput(Input.Split(Environment.NewLine));
        var result = await Problem.SolvePart1(input);
        result.Should().Be(198);
    }

    [Fact]
    public async Task Part2Test()
    {
        var input = Problem.ParseInput(Input.Split(Environment.NewLine));
        var result = await Problem.SolvePart2(input);
        result.Should().Be(230);
    }
}