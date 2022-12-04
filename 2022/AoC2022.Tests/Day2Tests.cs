using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day2Tests
{
    public ASolution Solution { get; set; }
    public Day2Tests()
    {
        Solution = new Day2(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("15");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("12");
    }
}