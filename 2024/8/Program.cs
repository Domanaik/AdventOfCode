using AdventOfCode._8;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);

        int rows = inputData.Length;
        int cols = inputData[0].Length;
        char[,] map = new char[rows, cols];
        HashSet<(int x, int y)> antennas = [];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = inputData[i][j];
                if (map[i, j] != '.')
                {
                    antennas.Add((i, j));
                }
            }
        }

        HashSet<(int x, int y)> uniquePositions = [];
        Dictionary<char, List<(int x, int y)>> frequencyMap = [];

        foreach ((int x, int y) antenna in antennas)
        {
            if (!frequencyMap.ContainsKey(map[antenna.x, antenna.y]))
            {
                frequencyMap[map[antenna.x, antenna.y]] = [];
            }
            frequencyMap[map[antenna.x, antenna.y]].Add(antenna);
        }

        foreach (KeyValuePair<char, List<(int x, int y)>> freqGroup in frequencyMap)
        {
            List<(int x, int y)> antennaList = freqGroup.Value;

            if (antennaList.Count < 2)
            {
                continue;
            }

            foreach ((int x, int y) antenna in antennaList)
            {
                uniquePositions.Add(antenna);

                foreach ((int x, int y) otherAntenna in antennaList)
                {
                    if (antenna == otherAntenna)
                    {
                        continue;
                    }

                    int step = 1;

                    while (true)
                    {
                        int currentX = antenna.x + step * (otherAntenna.x - antenna.x);
                        int currentY = antenna.y + step * (otherAntenna.y - antenna.y);

                        if (currentX < 0 || currentX >= map.GetLength(0) || currentY < 0 || currentY >= map.GetLength(1))
                        {
                            break;
                        }

                        if (map[currentX, currentY] == '.')
                        {
                            uniquePositions.Add((currentX, currentY));
                        }

                        step++;
                    }
                }
            }
        }

        Console.WriteLine(uniquePositions.Count);
    }
}