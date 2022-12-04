using AoCHelpers;

namespace AoC2022.Solutions;

public class Day2 : ASolution
{
    public Day2(bool testInput) : base(testInput) { }

    public override string A()
    {
        var rounds = Input.Select(x => new Round(x, 'A'));
        return rounds.Aggregate(0, (sum, next) => sum + next.GetPoints(), sum => sum.ToString());
    }

    public override string B()
    {
        var rounds = Input.Select(x => new Round(x, 'B'));
        return rounds.Aggregate(0, (sum, next) => sum + next.GetPoints(), sum => sum.ToString());
    }
}

public record Round
{
    public Shape Opponent { get; init; }
    public Shape Self { get; init; }
    public Outcome RoundOutcome { get; init; }

    public Round(string input, char task)
    {
        var split = input.Split(' ');
        Opponent = ParseShape(split[0]);

        switch (task)
        {
            case 'A':
                Self = ParseShape(split[1]);
                RoundOutcome = GetOutcome(Opponent, Self);
                break;
            case 'B':
                RoundOutcome = ParseOutcome(split[1]);
                Self = GetShape(Opponent, RoundOutcome);
                break;
        }
    }

    public int GetPoints()
    {
        return (int)Self + (int)RoundOutcome;
    }

    private static Shape ParseShape(string value)
    {
        return value switch
        {
            "A" or "X" => Shape.Rock,
            "B" or "Y" => Shape.Paper,
            "C" or "Z" => Shape.Scissor,
            _ => Shape.Unknown,
        };
    }

    private static Outcome ParseOutcome(string value)
    {
        return value switch
        {
            "X" => Outcome.Loss,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Win,
            _ => Outcome.Unknown,
        };
    }

    private static Outcome GetOutcome(Shape opponent, Shape self)
    {
        if (opponent == self)
            return Outcome.Draw;

        return (opponent, self) switch
        {
            (Shape.Rock, Shape.Paper) or (Shape.Paper, Shape.Scissor) or (Shape.Scissor, Shape.Rock) => Outcome.Win,
            _ => Outcome.Loss,
        };
    }

    private static Shape GetShape(Shape opponent, Outcome outcome)
    {
        return (outcome, opponent) switch
        {
            (Outcome.Loss, Shape.Rock) or (Outcome.Win, Shape.Paper) => Shape.Scissor,
            (Outcome.Loss, Shape.Paper) or (Outcome.Win, Shape.Scissor) => Shape.Rock,
            (Outcome.Loss, Shape.Scissor) or (Outcome.Win, Shape.Rock) => Shape.Paper,
            _ => opponent,
        };
    }
}

public enum Shape
{
    Unknown = int.MinValue,
    Rock = 1,
    Paper = 2,
    Scissor = 3
}

public enum Outcome
{
    Unknown = int.MinValue,
    Loss = 0,
    Draw = 3,
    Win = 6
}
