using AdventOfCode._5;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine + Environment.NewLine);
        string rulesSection = inputData[0];
        string updatesSection = inputData[1];

        List<(int First, int Second)> rules = [];
        foreach (string line in rulesSection.Split(Environment.NewLine))
        {
            int[] parts = line.Split('|').Select(int.Parse).ToArray();
            rules.Add((parts[0], parts[1]));
        }

        List<List<int>> updates = updatesSection.Split(Environment.NewLine).Select(line => line.Split(',').Select(int.Parse).ToList()).ToList();

        bool IsCorrectOrder(List<int> update)
        {
            Dictionary<int, int> positions = update.Select((page, index) => (Page: page, Index: index)).ToDictionary(x => x.Page, x => x.Index);

            foreach ((int First, int Second) in rules)
            {
                if (positions.ContainsKey(First) && positions.ContainsKey(Second))
                {
                    if (positions[First] > positions[Second])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static List<int> TopologicalSort(List<int> update, List<(int First, int Second)> rules)
        {
            Dictionary<int, List<int>> graph = [];
            Dictionary<int, int> inDegree = [];

            foreach (int page in update)
            {
                graph[page] = [];
                inDegree[page] = 0;
            }

            foreach ((int First, int Second) in rules)
            {
                if (graph.ContainsKey(First) && graph.ContainsKey(Second))
                {
                    graph[First].Add(Second);
                    inDegree[Second]++;
                }
            }

            Queue<int> queue = new(inDegree.Where(kv => kv.Value == 0).Select(kv => kv.Key));
            List<int> sorted = [];

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                sorted.Add(current);

                foreach (int neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }

            return sorted;
        }

        int partOneSum = 0;
        int partTwoSum = 0;

        foreach (List<int> update in updates)
        {
            if (IsCorrectOrder(update))
            {
                partOneSum += update[(update.Count - 1) / 2];
            }
            else
            {
                List<int> correctedUpdate = TopologicalSort(update, rules);
                partTwoSum += correctedUpdate[(correctedUpdate.Count - 1) / 2];
            }
        }

        Console.WriteLine(partOneSum);
        Console.WriteLine(partTwoSum);
    }
}