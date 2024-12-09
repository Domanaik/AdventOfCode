using AdventOfCode._9;

class Program
{
    static void Main(string[] args)
    {
        int[] inputData = Input.GetInput().Select(d => int.Parse(d.ToString())).ToArray();

        List<int> blocks = [];

        for (int i = 0; i < inputData.Length; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < inputData[i]; j++)
                {
                    blocks.Add(i / 2);
                }
            }
            else
            {
                for (int j = 0; j < inputData[i]; j++)
                {
                    blocks.Add(-1); // empty space
                }
            }
        }

        var emptySpaceGroups = new List<List<int>>();
        List<int>? currentEmptySpaceGroup = null;

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] == -1)
            {
                currentEmptySpaceGroup ??= [];
                currentEmptySpaceGroup.Add(i);
            }
            else
            {
                if (currentEmptySpaceGroup != null)
                {
                    emptySpaceGroups.Add(currentEmptySpaceGroup);
                    currentEmptySpaceGroup = null;
                }
            }
        }

        if (currentEmptySpaceGroup != null)
        {
            emptySpaceGroups.Add(currentEmptySpaceGroup);
        }

        var digitGroups = blocks
            .AsEnumerable()
            .Reverse()
            .Select((value, index) => new { value, index = blocks.Count - 1 - index })
            .Where(x => x.value != -1)
            .GroupBy(x => x.value)
            .Where(g => g.Count() > 0)
            .ToList();

        foreach (var group in digitGroups.ToList())
        {
            int emptySpaceIndex = 0;

            while (emptySpaceIndex < emptySpaceGroups.Count && (emptySpaceGroups[emptySpaceIndex].Last() > group.First().index || emptySpaceGroups[emptySpaceIndex].Count < group.Count()))
            {
                emptySpaceIndex++;
            }

            if (emptySpaceIndex < emptySpaceGroups.Count)
            {
                for (int j = 0; j < group.Count(); j++)
                {
                    blocks[emptySpaceGroups[emptySpaceIndex][j]] = group.Key;
                    blocks[group.ElementAt(j).index] = -1;
                }

                emptySpaceGroups[emptySpaceIndex].RemoveRange(0, group.Count());

                if (emptySpaceGroups[emptySpaceIndex].Count == 0)
                {
                    emptySpaceGroups.RemoveAt(emptySpaceIndex);
                }
            }
        }

        long checksum = 0;

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] == -1)
            {
                continue;
            }

            checksum += i * blocks[i];
        }

        Console.WriteLine(checksum);
    }
}