using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using AdventOfCode._4;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);

        int rows = inputData.Length;
        int cols = inputData[0].Length;
        int counter1 = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (inputData[i][j] != '@')
                    continue;

                int rollsOfPaperAsNeighbour = 0;

                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (y == 0 && x == 0)
                            continue;

                        int tmp_y = i + y;
                        int tmp_x = j + x;

                        if (tmp_y >= 0 && tmp_y < rows && tmp_x >= 0 && tmp_x < cols)
                        {
                            if (inputData[tmp_y][tmp_x] == '@')
                                rollsOfPaperAsNeighbour++;
                        }
                    }
                }

                if (rollsOfPaperAsNeighbour <= 3)
                    counter1++;
            }
        }

        int counter2 = 0;
        char[,] map = new char[rows, cols];
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                map[y, x] = inputData[y][x];
            }
        }

        while (true)
        {
            List<(int x, int y)> canBeRemoved = [];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i, j] != '@')
                        continue;

                    int rollsOfPaperAsNeighbour = 0;

                    for (int y = -1; y <= 1; y++)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            if (x == 0 && y == 0)
                                continue;

                            int tmp_y = y + i;
                            int tmp_x = x + j;

                            if (tmp_y >= 0 && tmp_y < rows && tmp_x >= 0 && tmp_x < cols)
                            {
                                if (map[tmp_y, tmp_x] == '@')
                                    rollsOfPaperAsNeighbour++;
                            }
                        }
                    }

                    if (rollsOfPaperAsNeighbour <= 3)
                        canBeRemoved.Add((i, j));
                }
            }

            if (canBeRemoved.Count == 0)
                break;

            foreach (var (y, x) in canBeRemoved)
                map[y, x] = 'x';

            counter2 += canBeRemoved.Count;
        }

        Console.WriteLine("Part 1: " + counter1);
        Console.WriteLine("Part 2: " + counter2);
    }
}