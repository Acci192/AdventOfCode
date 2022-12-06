using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day6Tests
{
    public ASolution Solution { get; set; }
    public Day6Tests()
    {
        Solution = new Day6(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("7");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("19");
    }
}