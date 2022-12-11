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

        for (var i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                ExecuteMonkeyTurn(monkey, monkeys);
            }
        }

        var test = monkeys.OrderByDescending(x => x.ActivityScore).Take(2).ToList();
        return (test[0].ActivityScore * test[1].ActivityScore).ToString();
    }

    public void ExecuteMonkeyTurn(Monkey monkey, List<Monkey> monkeys)
    {
        var itemCount = monkey.Items.Count;

        for (var i = 0; i < itemCount; i++)
        {
            monkey.ActivityScore++;
            var item = monkey.Items[0];
            monkey.Items.RemoveAt(0);

            //item = monkey.Calcalte(item);
            item = (monkey.ItemChangeFunc?.Invoke(item) ?? throw new Exception());
            item = item / 3;
            var target = monkey.ThrowTarget(item);
            monkeys[target].Items.Add(item);
        }
    }

    public IEnumerable<Monkey> GenerateMonkeys(IEnumerable<string> input)
    {
        var monkey = new Monkey();
        var divisable = 1L;
        var trueTarget = 0;
        var falseTarget = 0;
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
                    long? arg1 = long.TryParse(arguments[0], out var a1) ? a1 : null;
                    long? arg2 = long.TryParse(arguments[2], out var a2) ? a2 : null;
                    var operand = arguments[1];
                    //monkey.a1 = arg1;
                    //monkey.a2 = arg2;
                    //monkey.operand = operand;
                    monkey.ItemChangeFunc = ParseOperation(row);
                    break;
                case 3:
                    divisable = long.Parse(row.Split(' ').Last());
                    monkey.testd = divisable;
                    break;
                case 4:
                    trueTarget = int.Parse(row.Split(' ').Last());
                    monkey.test1 = trueTarget;
                    break;
                case 5:
                    falseTarget = int.Parse(row.Split(' ').Last());

                    monkey.test2 = falseTarget;
                    break;
                case 6:


                    monkey.ThrowTargetFunc = (x) => x % divisable == 0 ? trueTarget : falseTarget;
                    break;
            }
        }

        yield return monkey;
    }

    public Func<long, long>? ParseOperation(string row)
    {
        var arguments = row[19..].Split(' ');
        long? arg1 = long.TryParse(arguments[0], out var a1) ? a1 : null;
        long? arg2 = long.TryParse(arguments[2], out var a2) ? a2 : null;
        var operand = arguments[1];

        return operand switch
        {
            "+" => (x) => (arg1 ?? x) + (arg2 ?? x),
            "*" => (x) => (arg1 ?? x) * (arg2 ?? x),
            _ => null,
        };
    }

    public class Monkey
    {
        public List<long> Items { get; set; } = new List<long>();
        public Func<long, long>? ItemChangeFunc { get; set; }
        public Func<int, long>? ThrowTargetFunc { get; set; }

        public long testd { get; set; }
        public int test1 { get; set; }
        public int test2 { get; set; }


        public long? a1 { get; set; }
        public long? a2 { get; set; }
        public string operand { get; set; }
        
        public long ActivityScore = 0;
        public Monkey()
        {

        }
        public Monkey(List<long> items, Func<long, long> itemChangeFunc, Func<int, long> throwTargetFunc)
        {
            Items = items;
            ItemChangeFunc = itemChangeFunc;
            ThrowTargetFunc = throwTargetFunc;
        }
        public int ThrowTarget(long item)
        {
            return item % testd == 0 ? test1 : test2;
        }

        public long Calcalte(long x)
        {
            return operand switch
            {
                "+" => (a1 ?? x) + (a2 ?? x),
                "*" => (a1 ?? x) * (a2 ?? x),
                _ => -1,
            };
        }
    }
}
