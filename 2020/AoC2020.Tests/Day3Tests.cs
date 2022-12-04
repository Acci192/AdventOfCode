using AoC2020.Solutions;
using FluentAssertions;

namespace SolutionTests;

public class Day3Tests
{
    public ASolution Solution { get; set; }
    public Day3Tests()
    {
        Solution = new Day3(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("7");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("336");
    }
}