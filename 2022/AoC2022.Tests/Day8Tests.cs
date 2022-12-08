using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day8Tests
{
    public ASolution Solution { get; set; }
    public Day8Tests()
    {
        Solution = new Day8(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("21");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("8");
    }
}