using AdventOfCode._12;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetSample1().Split(Environment.NewLine);

        int rows = inputData.Length;
        int cols = inputData[0].Length;
        char[,] map = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = inputData[i][j];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }

        int[,] directions = {
            { 0, 1 },
            { 1, 0 },
            { 0, -1 },
            { -1, 0 }
        };
    }
}