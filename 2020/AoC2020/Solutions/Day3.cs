using AoCHelpers;

namespace AoC2020.Solutions;

public class Day3 : ASolution
{
    public Day3(bool testInput) : base(testInput) { }

    public override string A()
    {
        var map = Input.ToCoordinateDictionary(c => c == '#');

        return SequenceGenerator.GeneratePositions(Rows, 0, 0, 3, 1)
            .Count(pos => map.ContainsKey((pos.x % InputWidth, pos.y)))
            .ToString();
    }

    public override string B()
    {
        var map = Input.ToCoordinateDictionary(c => c == '#');
        var slopes = new (int x, int y)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

        return slopes
            .Select(slope => SequenceGenerator.GeneratePositions(Rows, 0, 0, slope.x, slope.y))
            .Select(positions => positions.Count(pos => map.ContainsKey((pos.x % InputWidth, pos.y))))
            .Aggregate(1L, (total, next) => total *= next)
            .ToString();
    }
}
