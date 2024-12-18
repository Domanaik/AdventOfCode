using AdventOfCode._18;

class Program
{
    static void Main(string[] args)
    {
        int[][] inputData = Input.GetInput()
            .Split(Environment.NewLine)
            .Select(line => line.Split(','))
            .Select(parts => new int[] { int.Parse(parts[0]), int.Parse(parts[1]) })
            .ToArray();

        int range = 70;

        char[,] memorySpace = new char[range + 1, range + 1];

        for (int i = 0; i <= range; i++)
        {
            for (int j = 0; j <= range; j++)
            {
                memorySpace[i, j] = '.';
            }
        }

        for (int i = 0; i < inputData.Length; i++)
        {
            memorySpace[inputData[i][0], inputData[i][1]] = '#';
            int steps = AStar(memorySpace, 0, 0, range, range);

            if (steps == -1)
            {
                Console.WriteLine($@"{inputData[i][0]},{inputData[i][1]}");
                break;
            }
        }
    }

    static int AStar(char[,] grid, int startX, int startY, int endX, int endY)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        int[][] directions =
        [
            [0, -1], // Up
            [0, 1],  // Down
            [-1, 0], // Left
            [1, 0]   // Right
        ];

        PriorityQueue<(int x, int y, int cost), int> priorityQueue = new();
        HashSet<(int x, int y)> visited = [];

        int Heuristic(int x, int y) => Math.Abs(x - endX) + Math.Abs(y - endY);

        priorityQueue.Enqueue((startX, startY, 0), Heuristic(startX, startY));

        while (priorityQueue.Count > 0)
        {
            var (x, y, cost) = priorityQueue.Dequeue();

            if (visited.Contains((x, y)))
            {
                continue;
            }

            visited.Add((x, y));

            if (x == endX && y == endY)
            {
                return cost;
            }

            foreach (var dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && grid[newX, newY] == '.' && !visited.Contains((newX, newY)))
                {
                    int newCost = cost + 1;
                    int priority = newCost + Heuristic(newX, newY);
                    priorityQueue.Enqueue((newX, newY, newCost), priority);
                }
            }
        }

        return -1;
    }
}