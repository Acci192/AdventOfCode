using AoCHelpers;
using System.Diagnostics.CodeAnalysis;

namespace AoC2022.Solutions;

public class Day8 : ASolution
{
    public Day8(bool testInput) : base(testInput) { }

    public override string A()
    {
        var grid = Input.ToCoordinateDictionary();

        var sum = 0;
        var width = InputWidth;
        var height = Rows;

        foreach(var position in grid)
        {
            var (x, y) = position.Key;
            if (x == 0 || y == 0 || x == InputWidth - 1 || y == InputWidth - 1)
            {
                sum++;
                continue;
            }

            var treesInTheWay = new List<char>();
            for(var i = x - 1; i >= 0; i--)
            {
                treesInTheWay.Add(grid[(i, y)]);
            }

            if (treesInTheWay.TrueForAll(tree => tree < grid[(x, y)]))
            {
                sum++;
                continue;
            }

            treesInTheWay = new List<char>();
            for (var i = y - 1; i >= 0; i--)
            {
                treesInTheWay.Add(grid[(x, i)]);
            }

            if (treesInTheWay.TrueForAll(tree => tree < grid[(x, y)]))
            {
                sum++;
                continue;
            }

            treesInTheWay = new List<char>();
            for (var i = x + 1; i < InputWidth; i++)
            {
                treesInTheWay.Add(grid[(i, y)]);
            }

            if (treesInTheWay.TrueForAll(tree => tree < grid[(x, y)]))
            {
                sum++;
                continue;
            }

            treesInTheWay = new List<char>();
            for (var i = y + 1; i < InputWidth; i++)
            {
                treesInTheWay.Add(grid[(x, i)]);
            }

            if (treesInTheWay.TrueForAll(tree => tree < grid[(x, y)]))
            {
                sum++;
                continue;
            }
        }
        return sum.ToString();
    }

    public override string B()
    {
        var grid = Input.ToCoordinateDictionary();

        var sum = 0;
        foreach (var position in grid)
        {
            var totalScore = 1;
            var (x, y) = position.Key;
            if (x == 0 || y == 0 || x == InputWidth - 1 || y == InputWidth - 1)
            {
                continue;
            }
            
            var treesInTheWay = new List<char>();
            for (var i = x - 1; i >= 0; i--)
            {
                treesInTheWay.Add(grid[(i, y)]);
            }

            var blocked = false;
            foreach (var (t, i) in treesInTheWay.Select((t, i) => (t, i)))
            {
                if (t >= grid[(x, y)])
                {
                    totalScore *= i + 1;
                    blocked = true;
                    break;
                }
            }
            if (!blocked)
            {
                totalScore *= treesInTheWay.Count;
            }

            treesInTheWay = new List<char>();
            for (var i = y - 1; i >= 0; i--)
            {
                treesInTheWay.Add(grid[(x, i)]);
            }
            blocked = false;
            foreach (var (t, i) in treesInTheWay.Select((t, i) => (t, i)))
            {
                if (t >= grid[(x, y)])
                {
                    totalScore *= i + 1;
                    blocked = true;
                    break;
                }
            }
            if (!blocked)
            {
                totalScore *= treesInTheWay.Count;
            }
            treesInTheWay = new List<char>();
            for (var i = x + 1; i < InputWidth; i++)
            {
                treesInTheWay.Add(grid[(i, y)]);
            }
            blocked = false;
            foreach (var (t, i) in treesInTheWay.Select((t, i) => (t, i)))
            {
                if (t >= grid[(x, y)])
                {
                    totalScore *= i+1;
                    blocked = true;
                    break;
                }
            }
            if (!blocked)
            {
                totalScore *= treesInTheWay.Count;
            }
            treesInTheWay = new List<char>();
            for (var i = y + 1; i < InputWidth; i++)
            {
                treesInTheWay.Add(grid[(x, i)]);
            }
            blocked = false;
            foreach (var (t, i) in treesInTheWay.Select((t, i) => (t, i)))
            {
                if (t >= grid[(x, y)])
                {
                    totalScore *= i + 1;
                    blocked = true;
                    break;
                }
            }
            if (!blocked)
            {
                totalScore *= treesInTheWay.Count;
            }
            sum = Math.Max(sum, totalScore);
        }
        return sum.ToString();
    }
}
