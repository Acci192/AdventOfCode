using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day9Tests
{
    public ASolution Solution { get; set; }
    public Day9Tests()
    {
        Solution = new Day9(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("13");
    }

    [Fact]
    public void B_1()
    {
        Solution.B().Should().Be("1");
    }

    [Fact]
    public void B_2()
    {
        Solution = new Day9(@"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20");

        Solution.B().Should().Be("36");
    }
}