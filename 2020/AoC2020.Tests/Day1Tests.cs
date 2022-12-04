using AoC2020.Solutions;
using FluentAssertions;

namespace SolutionTests;

public class Day0Tests
{
    public ASolution Solution { get; set; }
    public Day0Tests()
    {
        Solution = new Day0(true);
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