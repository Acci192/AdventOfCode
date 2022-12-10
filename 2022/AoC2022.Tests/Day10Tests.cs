using AoC2022.Solutions;
using AoCHelpers;
using FluentAssertions;

namespace SolutionTests;

public class Day10Tests
{
    public ASolution Solution { get; set; }
    public Day10Tests()
    {
        Solution = new Day10(true);
    }

    [Fact]
    public void A()
    {
        Solution.A().Should().Be("13140");
    }

    [Fact]
    public void B()
    {
        Solution.B().Should().Be(@"##  ##  ##  ##  ##  ##  ##  ##  ##  ##  
###   ###   ###   ###   ###   ###   ### 
####    ####    ####    ####    ####    
#####     #####     #####     #####     
######      ######      ######      ####
#######       #######       #######     ".Trim());
    }
}