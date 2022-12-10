using AoCHelpers;
using System.Diagnostics.CodeAnalysis;

namespace AoC2022.Solutions;

public class Day8 : ASolution
{
    public Day8(bool testInput) : base(testInput) { }

    public override string A()
    {
        var grid = Input.ToGrid(x => new Tree(x));

        for (var x = 0; x < grid[0].Length; x++)
        {
            for (var y = 0; y < grid.Length; y++)
            {
                PropagateVisibility(x, y, grid);
                PropagateVisibility(grid[0].Length - x - 1, grid.Length - y - 1, grid);
            }
        }

        return grid.SelectMany(x => x).Count(x => x.Visible).ToString();
    }

    public override string B()
    {
        var grid = Input.ToGrid(x => new Tree(x));

        var biggestScenicScore = 0;
        for (var x = 1; x < grid[0].Length -1; x++)
        {
            for (var y = 1; y < grid.Length - 1; y++)
            {
                var test = CalculateScenicScore(x, y, grid);
                biggestScenicScore = Math.Max(biggestScenicScore, test);
            }
        }

        return biggestScenicScore.ToString();
    }

    private static void PropagateVisibility(int x, int y, Tree[][] grid)
    {
        var tree = grid[y][x];

        if (y > 0)
        {
            grid[y - 1][x].BlockedByFromSouth = Math.Max(tree.Height, tree.BlockedByFromSouth);
        }

        if (y < grid.Length - 1)
        {
            grid[y + 1][x].BlockedByFromNorth = Math.Max(tree.Height, tree.BlockedByFromNorth);
        }

        if (x > 0)
        {
            grid[y][x - 1].BlockedByFromEast = Math.Max(tree.Height, tree.BlockedByFromEast);
        }

        if (x < grid[0].Length - 1)
        {
            grid[y][x + 1].BlockedByFromWest = Math.Max(tree.Height, tree.BlockedByFromWest);
        }
    }

    private static int CalculateScenicScore(int x, int y, Tree[][] grid)
    {
        var treesToNorth = 0;
        var treesToSouth = 0;
        var treesToEast = 0;
        var treesToWest = 0;

        var blockedToNorth = false;
        var blockedToSouth = false;
        var blockedToEast = false;
        var blockedToWest = false;

        var tree = grid[y][x];
        for(var i = 1; i <= grid.Length; i++)
        {
            if(x - i >= 0 && !blockedToWest)
            {
                treesToWest++;
                if (grid[y][x - i].Height >= tree.Height)
                {
                    blockedToWest = true;
                }
            }

            if (x + i < grid.Length && !blockedToEast)
            {
                treesToEast++;
                if (grid[y][x + i].Height >= tree.Height)
                {
                    blockedToEast = true;
                }
            }

            if(y - i >= 0 && !blockedToNorth)
            {
                treesToNorth++;
                if (grid[y - i][x].Height >= tree.Height)
                {
                    blockedToNorth = true;
                }
            }

            if(y + i < grid.Length && !blockedToSouth)
            {
                treesToSouth++;
                if (grid[y + i][x].Height >= tree.Height)
                {
                    blockedToSouth = true;
                }
            }

            if(blockedToSouth && blockedToWest && blockedToNorth && blockedToEast)
            {
                break;
            }
        }

        treesToNorth = Math.Max(treesToNorth, 1);
        treesToSouth = Math.Max(treesToSouth, 1);
        treesToEast = Math.Max(treesToEast, 1);
        treesToWest = Math.Max(treesToWest, 1);

        return treesToEast * treesToNorth * treesToSouth * treesToWest;
    }

    private class Tree
    {
        public int Height { get; set; }
        public int BlockedByFromNorth { get; set; } = -1;
        public int BlockedByFromSouth { get; set; } = -1;
        public int BlockedByFromWest { get; set; } = -1;
        public int BlockedByFromEast { get; set; } = -1;

        public bool Visible => Height > BlockedByFromEast
            || Height > BlockedByFromNorth
            || Height > BlockedByFromSouth
            || Height > BlockedByFromWest;

        public bool Blocked => BlockedByFromNorth >= Height
            && BlockedByFromSouth >= Height
            && BlockedByFromWest >= Height
            && BlockedByFromEast >= Height;

        public Tree(char height)
        {
            Height = height - '0';
        }

        public override string? ToString()
        {
            return Height.ToString();
        }
    }
}
