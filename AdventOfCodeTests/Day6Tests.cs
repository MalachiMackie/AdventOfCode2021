using System.Threading.Tasks;
using AdventOfCode2021.Day6;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day6Tests
{
    private const string Input = "3,4,3,1,2";
    
    [Fact]
    public async Task Part1Test()
    {
        var input = Problem.ParseInput(Input);
        var output = await Problem.SolvePart1(input);
        output.Should().Be(5934);
    }
    
    [Fact]
    public async Task Part2Test()
    {
        var input = Problem.ParseInput(Input);
        var output = await Problem.SolvePart2(input);
        output.Should().Be(26984457539);
    }
}