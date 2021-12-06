using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AdventOfCodeTests;

public class Day6Tests
{
    private const string Input = "3,4,3,1,2";
    
    [Fact]
    public async Task Part1Test()
    {
        var input = AdventOfCode2021.Day6.Problem.ParseInput(Input);
        var output = await AdventOfCode2021.Day6.Problem.SolvePart1(input);
        output.Should().Be(5934);
    }
    
    [Fact]
    public async Task Part2Test()
    {
        var input = AdventOfCode2021.Day6.Problem.ParseInput(Input);
        var output = await AdventOfCode2021.Day6.Problem.SolvePart2(input);
        output.Should().Be(26984457539);
    }
}