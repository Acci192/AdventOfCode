using AoC2020.Solutions;
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
        Solution.A().Should().Be("2");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("1");
    }
}