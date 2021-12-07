using System;
using System.Threading.Tasks;
using AdventOfCode2021.Day5;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day5Tests
{
    private const string Input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
    
    [Fact]
    public async Task Part1Test()
    {
        var input = Problem.ParseInput(Input.Split(Environment.NewLine));
        var output = await Problem.SolvePart1(input);
        output.Should().Be(5);
    }

    [Fact]
    public async Task Part2Test()
    {
        var input = Problem.ParseInput(Input.Split(Environment.NewLine));
        var output = await Problem.SolvePart2(input);
        output.Should().Be(12); 
    }
}