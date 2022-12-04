using AoC2022.Solutions;
using AoCHelpers;
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
        Solution.A().Should().Be("157");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("70");
    }
}