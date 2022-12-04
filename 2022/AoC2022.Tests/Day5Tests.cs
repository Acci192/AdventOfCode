using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day5Tests
{
    public ASolution Solution { get; set; }
    public Day5Tests()
    {
        Solution = new Day5(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("");
    }
}