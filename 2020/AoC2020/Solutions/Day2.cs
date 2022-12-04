namespace AoC2020.Solutions;

public class Day2 : ASolution
{
    public Day2(bool testInput) : base(testInput) { }

    public override string A()
    {
        return Input.Select(x => new PasswordPolicy(x)).Count(ValidatePolicyA).ToString();
    }

    public override string B()
    {
        return Input.Select(x => new PasswordPolicy(x)).Count(ValidatePolicyB).ToString();
    }

    private bool ValidatePolicyA(PasswordPolicy policy)
    {
        var keys = policy.Password.Count(c => c == policy.Key);

        return keys >= policy.Min && keys <= policy.Max;
    }

    private bool ValidatePolicyB(PasswordPolicy policy)
    {
        return policy.Password[policy.Min - 1] == policy.Key ^ policy.Password[policy.Max - 1] == policy.Key;
    }

    private class PasswordPolicy
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Key { get; set; }
        public string Password { get; set; }

        public PasswordPolicy(string input)
        {
            var split1 = input.Split(':');
            Password = split1[1].Trim();

            var split2 = split1[0].Split('-');
            Min = int.Parse(split2[0]);

            var split3 = split2[1].Split(" ");
            Max = int.Parse(split3[0]);

            Key = split3[1][0];
        }
    }
}
