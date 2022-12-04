namespace AoCHelpers;

public static class InputExtensions
{
    public static Dictionary<(int x, int y), char> ToCoordinateDictionary(this IEnumerable<string> input)
    {
        var result = new Dictionary<(int x, int y), char>();

        foreach(var (row, y) in input.Select((x, i) => (x, i)))
        {
            foreach(var (c, x) in row.Select((x, i) => (x, i)))
            {
                result.Add((x, y), c);
            }
        }

        return result;
    }

}