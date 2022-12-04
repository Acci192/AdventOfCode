using AoCHelpers;

namespace AoC2022.Solutions;

public class Day4 : ASolution
{
    public Day4(bool testInput) : base(testInput) { }

    public override string A()
    {
        return GetPairs(Input)
            .Count(pair => (pair.first.Start <= pair.second.Start && pair.first.End >= pair.second.End)
                || (pair.second.Start <= pair.first.Start && pair.second.End >= pair.first.End))
            .ToString();
    }

    public override string B()
    {
        return GetPairs(Input)
            .Count(pair => pair.first.Start <= pair.second.End && pair.second.Start <= pair.first.End)
            .ToString();
    }

    private static IEnumerable<(Assignment first, Assignment second)> GetPairs(IEnumerable<string> input)
    {
        foreach(var row in input)
        {
            var split = row.Split(',');
            yield return (new Assignment(split[0]), new Assignment(split[1]));
        }
    }

    private class Assignment
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Assignment(string input)
        {
            var split = input.Split('-');
            Start = int.Parse(split[0]);
            End = int.Parse(split[1]);
        }
    }
}
