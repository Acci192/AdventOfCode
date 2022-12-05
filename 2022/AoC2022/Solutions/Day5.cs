using AoCHelpers;
using System.Text;

namespace AoC2022.Solutions;

public class Day5 : ASolution
{
    public Day5(bool testInput) : base(testInput) { }

    public override string A()
    {
        var (stacks, instructions) = ParseData(Input.ToList());

        while (instructions.Any())
        {
            var instruction = instructions.Pop();
            ApplyInstructionA(stacks, instruction);
        }

        return string.Join("", stacks.Select(stack => stack.Pop()));
    }

    public override string B()
    {
        var (stacks, instructions) = ParseData(Input.ToList());

        while (instructions.Any())
        {
            var instruction = instructions.Pop();
            ApplyInstructionB(stacks, instruction);
        }

        return string.Join("", stacks.Select(stack => stack.Pop()));
    }

    private static void ApplyInstructionA(List<Stack<char>> stacks, Instruction instruction)
    {
        for(var i = 0; i < instruction.Amount; i++)
        {
            var crate = stacks[instruction.Source - 1].Pop();
            stacks[instruction.Destination - 1].Push(crate);
        }
    }

    private static void ApplyInstructionB(List<Stack<char>> stacks, Instruction instruction)
    {
        var temp = new Stack<char>();
        for (var i = 0; i < instruction.Amount; i++)
        {
            temp.Push(stacks[instruction.Source - 1].Pop());
        }

        while (temp.Any())
        {
            stacks[instruction.Destination - 1].Push(temp.Pop());
        }
    }

    private static (List<Stack<char>> stacks, Stack<Instruction> instructions) ParseData(List<string> input)
    {
        var stacks = new List<Stack<char>>();
        var instructions = new Stack<Instruction>();
        for(var i = input.Count - 1; i >= 0; i--)
        {
            if (string.IsNullOrWhiteSpace(input[i]))
            {
                continue;
            }
            else if (input[i].First() == 'm')
            {
                instructions.Push(new Instruction(input[i]));
                continue;
            }

            var chunks = input[i].Chunk(4).ToList();

            for(var j = 0; j < chunks.Count; j++)
            {
                if (char.IsDigit(chunks[j][1]))
                {
                    stacks.Add(new Stack<char>());
                    continue;
                }

                if (char.IsLetter(chunks[j][1]))
                {
                    stacks[j].Push(chunks[j][1]);
                }
            }
        }

        return (stacks, instructions);
    }

    private class Instruction
    {
        public int Amount { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }

        public Instruction(string input)
        {
            var split = input.Split(' ');
            Amount = int.Parse(split[1]);
            Source = int.Parse(split[3]);
            Destination = int.Parse(split[5]);
        }
    }
}
