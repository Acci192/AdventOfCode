using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day11Tests
{
    public ASolution Solution { get; set; }
    public Day11Tests()
    {
        Solution = new Day11(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("10605");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("2713310158");
    }
}