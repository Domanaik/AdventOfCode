// Credits to Korbinski @kojofl

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
        int counter = 0;

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

        while (true)
        {
            visited.Add(guard);

            int new_x = guard.x + directions[currentDirection].x;
            int new_y = guard.y + directions[currentDirection].y;

            if (new_x < 0 || new_x >= map.GetLength(0) || new_y < 0 || new_y >= map.GetLength(1))
            {
                break;
            }

            if (map[new_x, new_y] == obstruction)
            {
                currentDirection = (currentDirection + 1) % directions.Length;
            }
            else
            {
                if (!visited.Contains((new_x, new_y)))
                {
                    char[,] tempMap = (char[,])map.Clone(); // Danke C# !!

                    tempMap[new_x, new_y] = '#';
                    if (SimulateGuard(guard, currentDirection, tempMap))
                    {
                        counter++;
                    }
                }

                guard = (new_x, new_y);
            }
        }

        Console.WriteLine(visited.Count);
        Console.WriteLine(counter);
    }

    static bool SimulateGuard((int x, int y) guardPosition, int currentDirection, char[,] map)
    {
        (int x, int y)[] directions =
        [
            (-1,0), // North ^
            (0,1), // East >
            (1,0), // South v
            (0,-1), // West <
        ];

        HashSet<((int x, int y), int direction)> alreadyVisted = [];

        while (true)
        {
            if (alreadyVisted.Contains((guardPosition, currentDirection)))
            {
                return true; // Already visted
            }

            alreadyVisted.Add((guardPosition, currentDirection));

            int new_x = guardPosition.x + directions[currentDirection].x;
            int new_y = guardPosition.y + directions[currentDirection].y;

            if (new_x < 0 || new_x >= map.GetLength(0) || new_y < 0 || new_y >= map.GetLength(1))
            {
                return false;
            }

            if (map[new_x, new_y] == '#')
            {
                currentDirection = (currentDirection + 1) % directions.Length;
            }
            else
            {
                guardPosition = (new_x, new_y);
            }
        }
    }
}