using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using AdventOfCode._3;

class Program
{
    static void Main(string[] args)
    {
        string inputData = Input.GetInput();
        string regex_mul = @"mul\((\d{1,3}),(\d{1,3})\)";

        IEnumerable<(int First, int Second)> memory = Regex.Matches(inputData, regex_mul).Select(match => (First: int.Parse(match.Groups[1].Value), Second: int.Parse(match.Groups[2].Value)));

        int sum = memory.Sum(pair => pair.First * pair.Second);

        Console.WriteLine(sum);

        string regex_do = @"do\(\)";
        string regex_dont = @"don't\(\)";

        bool mulEnabled = true;
        sum = 0;

        foreach (Match match in Regex.Matches(inputData, $@"{regex_mul}|{regex_do}|{regex_dont}"))
        {
            if (Regex.IsMatch(match.Value, regex_do))
            {
                mulEnabled = true;
            }
            else if (Regex.IsMatch(match.Value, regex_dont))
            {
                mulEnabled = false;
            }
            else if (mulEnabled)
            {
                var groups = Regex.Match(match.Value, regex_mul).Groups;
                int First = int.Parse(groups[1].Value);
                int Second = int.Parse(groups[2].Value);
                sum += First * Second;
            }
        }

        Console.WriteLine(sum);
    }
}