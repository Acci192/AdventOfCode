using AoC2020.Solutions;
using FluentAssertions;

namespace SolutionTests;

public class Day1Tests
{
    public ASolution Solution { get; set; }
    public Day1Tests()
    {
        Solution = new Day1(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("514579");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("241861950");
    }
}