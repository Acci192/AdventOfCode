using AoCHelpers;

namespace AoC2022.Solutions;

public class Day3 : ASolution
{
    public Day3(bool testInput) : base(testInput) { }

    public override string A()
    {
        return Input
            .Select(row => row.Chunk(row.Length / 2))
            .Select(compartments => compartments.First().Intersect(compartments.Last()).Single())
            .Sum(CalculatePriority).ToString();
    }

    public override string B()
    {
        return Input
            .Chunk(3)
            .Select(group => group[0].Intersect(group[1]).Intersect(group[2]).Single())
            .Sum(CalculatePriority).ToString();
    }

    private int CalculatePriority(char c)
    {
        return (char.IsUpper(c) 
            ? c - 'A'+ 26
            : c - 'a') + 1 ;
    }
}
