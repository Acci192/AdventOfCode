using AoCHelpers;

namespace AoC2020.Solutions;

public class Day3 : ASolution
{
    public Day3(bool testInput) : base(testInput) { }

    public override string A()
    {
        var map = Input.ToCoordinateDictionary();

        var x = 0;
        var trees = 0;
        for(var y = 1; y < Input.Count(); y++)
        {
            x += 3;
            if (map[(x % Input.First().Length, y)] == '#')
            {
                trees++;
            }
        }
        return trees.ToString();
    }

    public override string B()
    {
        var map = Input.ToCoordinateDictionary();
        var slopes = new (int x, int y)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

        long result = 1;
        foreach(var slope in slopes)
        {
            var trees = 0;
            var x = 0;
            for(var y = slope.y; y < Input.Count(); y += slope.y)
            {
                x += slope.x;
                if (map[(x % Input.First().Length, y)] == '#')
                {
                    trees++;
                }
            }
            result *= trees;
        }
        return result.ToString();
    }
}
