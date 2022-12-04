namespace AoC2020.Solutions;

public abstract class ASolution
{
    public IEnumerable<string> Input;
    public IEnumerable<int> InputAsInts => Input.Select(x => int.TryParse(x, out var value) ? value : int.MinValue);

    protected ASolution(bool testInput)
    {
        Input = ReadInput(testInput);
    }

    public abstract string A();
    public abstract string B();

    public IEnumerable<string> ReadInput(bool testInput = false)
    {
        using var reader = new StreamReader(testInput ? $"../../../../AoC2020.Tests/TestInputs/{GetType().Name}.txt" : $"../../../Inputs/{GetType().Name}.txt");
        while (!reader.EndOfStream)
        {
            yield return reader.ReadLine() ?? string.Empty;
        }
    }
}
