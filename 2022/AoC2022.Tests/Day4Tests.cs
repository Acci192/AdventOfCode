using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day4Tests
{
    public ASolution Solution { get; set; }
    public Day4Tests()
    {
        Solution = new Day4(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("2");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("4");
    }
}