using System.Data;
using System.Threading.Tasks.Dataflow;
using AdventOfCode._4;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        (int, int)[] directons =
        [
            (0,1), // Right
            (0,-1), // Left
            (1,0), // Bottom
            (-1,0), // Top
            (1,1), // Bottom Right
            (-1,-1), // Top Left
            (1,-1), // Bottom Left
            (-1,1) // Top Right
        ];

        int xmasCount = 0;
        int x_masCount = 0;

        for (int i = 0; i < inputData.Length; i++)
        {
            for (int j = 0; j < inputData[0].Length; j++)
            {
                if (inputData[i][j].Equals('X'))
                {
                    foreach (var (xx, yy) in directons)
                    {
                        try
                        {
                            if (inputData[i + 1 * xx][j + 1 * yy].Equals('M') &&
                                inputData[i + 2 * xx][j + 2 * yy].Equals('A') &&
                                inputData[i + 3 * xx][j + 3 * yy].Equals('S'))
                            {
                                xmasCount++;
                            }
                        }
                        catch
                        {
                            // If IndexOutOfRange, just ignore it :-)
                        }
                    }
                }

                if (inputData[i][j].Equals('A'))
                {
                    try
                    {
                        int count = 0;
                        if ((inputData[i + 1][j + 1].Equals('M') && inputData[i - 1][j - 1].Equals('S'))) { count++; /* M rechts unten, S links oben */ }
                        if ((inputData[i + 1][j - 1].Equals('M') && inputData[i - 1][j + 1].Equals('S'))) { count++; /* M links unten, S rechts oben */ }
                        if ((inputData[i + 1][j + 1].Equals('S') && inputData[i - 1][j - 1].Equals('M'))) { count++; /* S rechts unten, M links oben */ }
                        if ((inputData[i + 1][j - 1].Equals('S') && inputData[i - 1][j + 1].Equals('M'))) { count++; /* S links unten, M rechts oben */ }
                        if (count == 2) { x_masCount++; }
                    }
                    catch
                    {
                        // If IndexOutOfRange, just ignore it :-)
                    }
                }
            }
        }
        Console.WriteLine(xmasCount);
        Console.WriteLine(x_masCount);
    }
}