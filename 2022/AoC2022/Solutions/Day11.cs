using AoCHelpers;

namespace AoC2022.Solutions;

public class Day11 : ASolution
{
    public Day11(bool testInput) : base(testInput) { }

    public override string A()
    {
        var monkeys = GenerateMonkeys(Input).ToList();

        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                ExecuteMonkeyTurn(monkey, monkeys);
            }
        }

        var test = monkeys.OrderByDescending(x => x.ActivityScore).Take(2).ToList();
        return (test[0].ActivityScore * test[1].ActivityScore).ToString();
    }

    public override string B()
    {
        var monkeys = GenerateMonkeys(Input).ToList();

        var commonDivisor = monkeys.Select(x => x.Divisor).Aggregate(1L, (last, next) => next * last);
        for (var i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                ExecuteMonkeyTurn(monkey, monkeys, commonDivisor);
            }
        }

        var test = monkeys.OrderByDescending(x => x.ActivityScore).Take(2).ToList();
        return (test[0].ActivityScore * test[1].ActivityScore).ToString();
    }

    public static void ExecuteMonkeyTurn(Monkey monkey, List<Monkey> monkeys)
    {
        var itemCount = monkey.Items.Count;

        for (var i = 0; i < itemCount; i++)
        {
            monkey.ActivityScore++;
            var item = monkey.Items[0];
            monkey.Items.RemoveAt(0);

            item = monkey.Calculate(item);

            item /= 3;
            var target = monkey.ThrowTarget(item);

            monkeys[target].Items.Add(item);
        }
    }

    public static void ExecuteMonkeyTurn(Monkey monkey, List<Monkey> monkeys, long commonDivisor)
    {
        var itemCount = monkey.Items.Count;

        for (var i = 0; i < itemCount; i++)
        {
            monkey.ActivityScore++;
            var item = monkey.Items[0];
            monkey.Items.RemoveAt(0);

            item = monkey.Calculate(item, commonDivisor);

            var target = monkey.ThrowTarget(item);

            monkeys[target].Items.Add(item);
        }
    }

    public static IEnumerable<Monkey> GenerateMonkeys(IEnumerable<string> input)
    {
        var monkey = new Monkey();
        foreach (var (row, i) in input.Select((r, i) => (r, i)))
        {
            switch (i % 7)
            {
                case 0 when i == 0:
                    monkey = new Monkey();
                    break;
                case 0:
                    yield return monkey;
                    monkey = new Monkey();
                    break;
                case 1:
                    monkey.Items = row[18..].Split(',').Select(long.Parse).ToList();
                    break;
                case 2:
                    var arguments = row[19..].Split(' ');
                    monkey.Argument1 = long.TryParse(arguments[0], out var a1) ? a1 : null;
                    monkey.Argument2 = long.TryParse(arguments[2], out var a2) ? a2 : null;
                    monkey.Operand = arguments[1];
                    break;
                case 3:
                    monkey.Divisor = long.Parse(row.Split(' ').Last());
                    break;
                case 4:
                    monkey.Target1 = int.Parse(row.Split(' ').Last());
                    break;
                case 5:
                    monkey.Target2 = int.Parse(row.Split(' ').Last());
                    break;
            }
        }

        yield return monkey;
    }

    public class Monkey
    {
        public List<long> Items { get; set; } = new List<long>();

        public long Divisor { get; set; }
        public int Target1 { get; set; }
        public int Target2 { get; set; }


        public long? Argument1 { get; set; }
        public long? Argument2 { get; set; }
        public string? Operand { get; set; }
        
        public long ActivityScore = 0;
        public int ThrowTarget(long item)
        {
            return item % Divisor == 0 ? Target1 : Target2;
        }

        public long Calculate(long x)
        {
            return Operand switch
            {
                "+" => (Argument1 ?? x) + (Argument2 ?? x),
                "*" => (Argument1 ?? x) * (Argument2 ?? x),
                _ => -1,
            };
        }

        public long Calculate(long x, long commonDivisor)
        {
            return Operand switch
            {
                "+" => ((Argument1 ?? x) + (Argument2 ?? x)) % commonDivisor,
                "*" => ((Argument1 ?? x) * (Argument2 ?? x )) % commonDivisor,
                _ => -1,
            };
        }
    }
}
