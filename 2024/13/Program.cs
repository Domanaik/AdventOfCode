using System.Net.Http.Headers;
using AdventOfCode._13;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine + Environment.NewLine);

        long totalTokens = 0;

        foreach (string block in inputData)
        {
            string[] lines = block.Split(Environment.NewLine);

            (int X, int Y) buttonA = ParseCoordinates(lines[0]);
            (int X, int Y) buttonB = ParseCoordinates(lines[1]);
            (long X, long Y) prize = ParseCoordinates(lines[2]);

            totalTokens += GetCost(buttonA, buttonB, prize);
        }

        Console.WriteLine(totalTokens);
    }

    static (int X, int Y) ParseCoordinates(string line)
    {
        string[] parts = line.Split(',');
        int x = int.Parse(parts[0].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        int y = int.Parse(parts[1].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        return (x, y);
    }

    static long GetCost((int X, int Y) buttonA, (int X, int Y) buttonB, (long X, long Y) prize)
    {
        prize.X += 10000000000000;
        prize.Y += 10000000000000;

        long b = (buttonA.Y * prize.X - buttonA.X * prize.Y) / (buttonA.Y * buttonB.X - buttonA.X * buttonB.Y);
        long a = (prize.X - buttonB.X * b) / buttonA.X;

        if (a >= 0 && b >= 0 && (buttonA.X * a + buttonB.X * b == prize.X) && (buttonA.Y * a + buttonB.Y * b == prize.Y))
        {
            return 3 * a + 1 * b;
        }

        return 0;
    }
}