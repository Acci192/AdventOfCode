using AoCHelpers;

namespace AoC2022.Solutions;

public class Day1 : ASolution
{
    public Day1(bool testInput) : base(testInput) { }

    public override string A()
    {
        var elfs = GetElfs();

        return elfs.Max().ToString();
    }

    public override string B()
    {
        var elfs = GetElfs();

        return elfs.OrderByDescending(x => x).Take(3).Sum().ToString();
    }

    private IEnumerable<int> GetElfs()
    {
        var elf = 0;
        foreach (var c in InputAsInts)
        {
            if (c == int.MinValue)
            {
                yield return elf;

                elf = 0;
                continue;
            }

            elf += c;
        }

        yield return elf;
    }
}
