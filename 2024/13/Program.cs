using System.Net.Http.Headers;
using AdventOfCode._13;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine + Environment.NewLine);

        int totalTokens = 0;

        foreach (var block in inputData)
        {
            var lines = block.Split(Environment.NewLine);

            var buttonA = ParseCoordinates(lines[0]);
            var buttonB = ParseCoordinates(lines[1]);
            var prize = ParseCoordinates(lines[2]);

            (int? PushesA, int? PushesB, int Cost) = GetBestCombination(buttonA, buttonB, prize);

            if (PushesA.HasValue && PushesB.HasValue)
            {
                totalTokens += Cost;
            }
        }

        Console.WriteLine(totalTokens);
    }

    static (int X, int Y) ParseCoordinates(string line)
    {
        var parts = line.Split(',');
        int x = int.Parse(parts[0].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        int y = int.Parse(parts[1].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        return (x, y);
    }

    static (int? PushesA, int? PushesB, int Cost) GetBestCombination((int X, int Y) buttonA, (int X, int Y) buttonB, (int X, int Y) prize)
    {
        const int maxPresses = 100;
        const int costA = 3;
        const int costB = 1;
        int? bestA = null;
        int? bestB = null;
        int minCost = int.MaxValue;

        for (int a = 0; a <= maxPresses; a++)
        {
            for (int b = 0; b <= maxPresses; b++)
            {
                int totalX = a * buttonA.X + b * buttonB.X;
                int totalY = a * buttonA.Y + b * buttonB.Y;

                if (totalX > prize.X || totalY > prize.Y)
                {
                    break;
                }

                if (totalX == prize.X && totalY == prize.Y)
                {
                    int cost = a * costA + b * costB;

                    if (cost < minCost)
                    {
                        bestA = a;
                        bestB = b;
                        minCost = cost;
                    }
                }
            }
        }

        return (bestA, bestB, minCost);
    }
}