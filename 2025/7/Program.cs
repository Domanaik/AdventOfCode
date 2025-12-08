using AdventOfCode._7;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);

        int beamSplit = 0;

        int rows = inputData.Length;
        int cols = inputData[0].Length;

        char[,] map = new char[rows, cols];
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                map[y, x] = inputData[y][x];
            }
        }

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (map[y, x] == 'S' || map[y, x] == '|')
                {
                    if (y + 1 >= rows)
                        break;

                    if (map[y + 1, x] == '^')
                    {
                        beamSplit++;
                        map[y + 1, x - 1] = '|';
                        map[y + 1, x + 1] = '|';
                    }
                    else
                    {
                        map[y + 1, x] = '|';
                    }
                }
            }
        }

        Console.WriteLine("Part 1: " + beamSplit);
    }
}