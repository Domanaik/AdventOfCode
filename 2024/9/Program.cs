using AdventOfCode._9;

class Program
{
    static void Main(string[] args)
    {
        int[] inputData = Input.GetSample().Select(d => int.Parse(d.ToString())).ToArray();

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

        Console.WriteLine(string.Join("", blocks.Select(x => x == -1 ? "." : x.ToString())));

        var emptySpaceGroups = new List<List<int>>();
        List<int> currentEmptySpaceGroup = null;

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] == -1)
            {
                if (currentEmptySpaceGroup == null)
                {
                    currentEmptySpaceGroup = new List<int>();
                }
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

        int emptySpaceIndex = 0;

        while (digitGroups.Count > 0)
        {
            foreach (var group in digitGroups.ToList())
            {
                // Find the first empty space group that is big enough and to the left
                Console.WriteLine(emptySpaceIndex);
                Console.WriteLine(emptySpaceGroups.Count);
                Console.WriteLine(emptySpaceGroups[emptySpaceIndex].Count);
                Console.WriteLine(group.Count());
            }

            /*
            for (int j = 0; j < group.Count(); j++)
            {
                blocks[emptySpace[j]] = group.Key;
                blocks[group.ElementAt(j).index] = -1;
            }
            */

            Console.WriteLine(string.Join("", blocks.Select(x => x == -1 ? "." : x.ToString())));
            break;
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