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

        var digitGroups = blocks
            .AsEnumerable()
            .Select((value, index) => new { value, index })
            .Where(x => x.value != -1)
            .GroupBy(x => x.value)
            .Where(g => g.Count() > 0)
            .ToList();


        for (int i = digitGroups.Count - 1; i >= 0; i--)
        {
            var emptySpaces = blocks
                .Select((n, i) => new { n, i })
                .Where(x => x.n == -1)
                .GroupBy(
                    x => x.i - blocks.Take(x.i).Count(y => y == -1),
                    (key, group) => group.Select(g => g.i).ToList()
                )
                .ToList();

            var currentGroup = digitGroups[i];

            var targetEmptySpace = emptySpaces
                .Where(space => space.Count >= currentGroup.Count() && space.First() < currentGroup.First().index)
                .FirstOrDefault();

            if (targetEmptySpace != null)
            {
                for (int j = 0; j < currentGroup.Count(); j++)
                {
                    blocks[targetEmptySpace[j]] = currentGroup.Key;
                    blocks[currentGroup.ElementAt(j).index] = -1;
                }

                Console.WriteLine($"{i} of {digitGroups.Count - 1}");
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