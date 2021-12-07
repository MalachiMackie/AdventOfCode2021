using System.Threading.Tasks;
using AdventOfCode2021.Day7;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day7Tests
{
    private const string Input = "16,1,2,0,4,2,7,1,2,14";
    
    [Fact]
    public async Task Part1Test()
    {
        var input = Problem.ParseInput(Input);
        var output = await Problem.SolvePart1(input);
        output.Should().Be(37);
    }
    
    [Fact]
    public async Task Part2Test()
    {
        var input = Problem.ParseInput(Input);
        var output = await Problem.SolvePart2(input);
        output.Should().Be(168);
    }
}