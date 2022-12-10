using AoCHelpers;

namespace AoC2022.Solutions;

public class Day9 : ASolution
{
    public Day9(bool testInput) : base(testInput) { }
    public Day9(string input) : base(input) { }

    public override string A()
    {
        var visitedPositions = new HashSet<Position>();

        var head = new Position(0, 0);
        var tail = new Position(0, 0);

        foreach(var row in Input)
        {
            var split = row.Split(' ');
            var direction = split[0];
            var distance = int.Parse(split[1]);

            for(var i = 0; i < distance; i++)
            {
                head = FollowDirection(head, direction);

                tail = FollowHead(tail, head);

                visitedPositions.Add(tail);
            }

        }
        return visitedPositions.Count.ToString();
    }

    public override string B()
    {
        var visitedPositions = new HashSet<Position>();
        var knots = Enumerable.Repeat(new Position(0, 0), 10).ToList();

        foreach (var row in Input)
        {
            var split = row.Split(' ');
            var direction = split[0];
            var distance = int.Parse(split[1]);

            for (var i = 0; i < distance; i++)
            {
                knots[0] = FollowDirection(knots.First(), direction);

                for(var j = 1; j < knots.Count; j++)
                {
                    knots[j] = FollowHead(knots[j], knots[j - 1]);
                }

                visitedPositions.Add(knots.Last());
            }

        }
        return visitedPositions.Count.ToString();
    }

    private static Position FollowHead(Position tail, Position head)
    {
        if (CalulateDistance(tail, head) <= 1.5)
        {
            return tail;
        }

        if (tail.X == head.X)
        {
            return tail with
            {
                Y = tail.Y < head.Y ? tail.Y + 1 : tail.Y - 1
            };
        }

        if (tail.Y == head.Y)
        {
            return tail with
            {
                X = tail.X < head.X ? tail.X + 1 : tail.X - 1,
            };
        }

        return tail with
        {
            X = tail.X < head.X ? tail.X + 1 : tail.X - 1,
            Y = tail.Y < head.Y ? tail.Y + 1 : tail.Y - 1
        };
    }

    private static Position FollowDirection(Position head, string direction)
    {
        return direction switch
        {
            "U" => head with { Y = head.Y - 1 },
            "D" => head with { Y = head.Y + 1 },
            "L" => head with { X = head.X - 1 },
            "R" => head with { X = head.X + 1 },
            _ => head
        };
    }

    private static double CalulateDistance(Position p1, Position p2)
    {
        return Math.Sqrt( Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }

    private record Position(int X, int Y);
}
