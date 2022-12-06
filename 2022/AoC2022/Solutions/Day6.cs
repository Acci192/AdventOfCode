using AoCHelpers;

namespace AoC2022.Solutions;

public class Day6 : ASolution
{
    public Day6(bool testInput) : base(testInput) { }

    public override string A()
    {
        var input = Input.First();

        var validator = new Queue<char>(4);
        foreach (var (c, i) in input.Select((c, i) => (c, i)))
        {
            if (Validate(validator, 4))
            {
                return i.ToString();
            }

            if (validator.Count == 4)
                validator.Dequeue();

            validator.Enqueue(c);
        }
        return string.Empty;
    }

    public override string B()
    {
        var input = Input.First();

        var validator = new Queue<char>(14);
        foreach (var (c, i) in input.Select((c, i) => (c, i)))
        {
            if (Validate(validator, 14))
            {
                return i.ToString();
            }

            if (validator.Count == 14)
                validator.Dequeue();

            validator.Enqueue(c);
        }
        return string.Empty;
    }

    private bool Validate(Queue<char> chars, int size)
    {
        if (chars.Count == size)
        {
            return chars.Distinct().Count() == size;
        }
        return false;
    }
}
