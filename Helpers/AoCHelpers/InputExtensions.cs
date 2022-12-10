namespace AoCHelpers;

public static class InputExtensions
{
    public static Dictionary<(int x, int y), char> ToCoordinateDictionary(this IEnumerable<string> input)
    {
        return input.ToCoordinateDictionary(c => true);
    }

    public static Dictionary<(int x, int y), char> ToCoordinateDictionary(this IEnumerable<string> input, Func<char, bool> predicate)
    {
        var result = new Dictionary<(int x, int y), char>();

        foreach (var (row, y) in input.Select((x, i) => (x, i)))
        {
            foreach (var (c, x) in row.Select((x, i) => (x, i)))
            {
                if (predicate(c))
                {
                    result.Add((x, y), c);
                }
            }
        }

        return result;
    }

    public static char[][] ToCharGrid(this IEnumerable<string> input)
    {
        return input.Select(x => x.ToArray()).ToArray();
    }

    public static T[][] ToGrid<T>(this IEnumerable<string> input, Func<char, T> selector)
    {
        return input.Select(x => x.Select(selector).ToArray()).ToArray();
    }
}