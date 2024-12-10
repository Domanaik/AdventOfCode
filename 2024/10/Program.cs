using System.ComponentModel;
using System.Runtime.CompilerServices;
using AdventOfCode._10;

class Program
{
    static void Main(string[] args)
    {
        int[][] inputData = Input.GetInput()
            .Split(Environment.NewLine)
            .Select(line => line
                .Select(ch => ch - '0')
                .ToArray())
            .ToArray();

        (int x, int y)[] directions =
        [
            (0,-1), // North
            (1,0), // East
            (0,1), // South
            (-1,0), // West
        ];

        int trailRating = 0;

        for (int y = 0; y < inputData.Length; y++)
        {
            for (int x = 0; x < inputData[y].Length; x++)
            {
                if (inputData[y][x] == 0)
                {
                    trailRating += CountFullTrails(inputData, x, y, 0, directions);
                }
            }
        }

        Console.WriteLine(trailRating);
    }

    static int CountFullTrails(int[][] inputData, int startX, int startY, int currentStep, (int x, int y)[] directions)
    {
        if (currentStep == 9)
        {
            return 1;
        }

        int totalTrails = 0;

        foreach (var (x, y) in directions)
        {
            int newX = startX + x;
            int newY = startY + y;

            if (newX < 0 || newY < 0 || newY >= inputData.Length || newX >= inputData[newY].Length)
            {
                continue;
            }

            if (inputData[newY][newX] == currentStep + 1)
            {
                totalTrails += CountFullTrails(inputData, newX, newY, currentStep + 1, directions);
            }
        }

        return totalTrails;
    }
}