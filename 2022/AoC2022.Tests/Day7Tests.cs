using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day7Tests
{
    public ASolution Solution { get; set; }
    public Day7Tests()
    {
        Solution = new Day7(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("95437");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be("24933642");
    }
}