using AoCHelpers;

namespace AoC2020.Solutions;

public class Day1 : ASolution
{
    public Day1(bool testInput) : base(testInput) { }

    public override string A()
    {
        foreach(var i in InputAsInts)
        {
            foreach(var j in InputAsInts)
            {
                if(i + j == 2020)
                {
                    return (i * j).ToString();
                }
            }
        }
        return string.Empty;
    }

    public override string B()
    {
        foreach (var i in InputAsInts)
        {
            foreach (var j in InputAsInts)
            {
                foreach (var k in InputAsInts)
                {
                    if (i + j + k == 2020)
                    {
                        return (i * j * k).ToString();
                    }
                }
            }
        }
        return string.Empty;
    }
}
