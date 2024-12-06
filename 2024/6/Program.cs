using AdventOfCode._6;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        (int x, int y)[] directions =
        [
            (-1,0), // North ^
            (0,1), // East >
            (1,0), // South v
            (0,-1), // West <
        ];

        int rows = inputData.Length;
        int cols = inputData[0].Length;

        char[,] map = new char[rows, cols];
        HashSet<(int, int)> visited = [];

        int currentDirection = 0;
        (int x, int y) guard = (0, 0);
        const char obstruction = '#';
        const string possibleDirections = "^>v<";

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = inputData[i][j];
                if (possibleDirections.Contains(map[i, j]))
                {
                    guard = (i, j);
                    currentDirection = possibleDirections.IndexOf(map[i, j]);
                }
            }
        }

        try
        {
            while (true)
            {
                visited.Add(guard);

                int new_x = guard.x + directions[currentDirection].x;
                int new_y = guard.y + directions[currentDirection].y;

                if (map[new_x, new_y] == obstruction)
                {
                    currentDirection = (currentDirection + 1) % 4;
                }
                else
                {
                    guard = (new_x, new_y);
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            // As always, if IndexOutOfRange, just ignore it :-)
        }

        Console.WriteLine(visited.Count);
    }
}