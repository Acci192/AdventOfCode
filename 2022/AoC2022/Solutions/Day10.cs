using AoCHelpers;

namespace AoC2022.Solutions;

public class Day10 : ASolution
{
    public Day10(bool testInput) : base(testInput) { }

    public override string A()
    {
        var instructions = Input.Select(x => new Instruction(x));

        var keyTicks = new List<int>() { 20, 60, 100, 140, 180, 220 };
        var keyIndex = 0;

        var sum = 0;
        var computer = new Computer(40);
        foreach(var instruction in instructions)
        {
            var prevValue = computer.SpritePosition;
            computer.PerformInstruction(instruction);

            if(keyIndex >= keyTicks.Count || computer.TickCounter < keyTicks[keyIndex])
            {
                continue;
            }

            if (computer.TickCounter > keyTicks[keyIndex])
            {
                sum += (prevValue * keyTicks[keyIndex]);
            }
            else if (computer.TickCounter == keyTicks[keyIndex])
            {
                sum += (computer.SpritePosition * keyTicks[keyIndex]);
            }

            keyIndex++;
        }
        return sum.ToString();
    }

    public override string B()
    {
        var instructions = Input.Select(x => new Instruction(x));

        var computer = new Computer(40);
        foreach (var instruction in instructions)
        {
            var prevValue = computer.SpritePosition;
            computer.PerformInstruction(instruction);
        }
        return computer.GetDrawing();
    }

    private class Computer
    {
        public int Width { get; set; }
        public int SpritePosition { get; private set; } = 1;
        public int TickCounter { get; private set; } = 1;

        private int _crtPosition => (TickCounter - 1) % Width;
        private readonly List<List<char>> _drawing = new() { new List<char>()};
        
        public Computer(int width)
        {
            Width = width;
        }

        private void ExecuteTick()
        {
            if(_crtPosition == 0)
            {
                _drawing.Add(new List<char>());
            }

            if (_crtPosition == SpritePosition || _crtPosition - 1 == SpritePosition || _crtPosition + 1 == SpritePosition)
            {
                _drawing[(TickCounter - 1) / Width].Add('#');
            }
            else
            {
                _drawing[(TickCounter - 1) / Width].Add(' ');
            }
            TickCounter++;
        }

        public void PerformInstruction(Instruction instruction)
        {
            switch (instruction.Type)
            {
                case "noop":
                    ExecuteTick();
                    break;
                case "addx":
                    ExecuteTick();
                    ExecuteTick();
                    SpritePosition += int.Parse(instruction.Arguments.First());
                    break;
            }
        }

        public string GetDrawing()
        {
            return string.Join(Environment.NewLine, _drawing.Select(x => new string(x.ToArray()))).Trim();
        }
    }

    private class Instruction
    {
        public string Type { get; set;}
        public List<string> Arguments { get; set;}

        public Instruction(string row)
        {
            var split = row.Split(' ');
            Type = split[0];
            Arguments = split.Skip(1).ToList();
        }
    }
}
