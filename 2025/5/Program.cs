using AdventOfCode._5;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine + Environment.NewLine);

        string[] freshIngredientIDRanges = inputData[0].Split(Environment.NewLine);
        string[] availableIngredientIDs = inputData[1].Split(Environment.NewLine);

        int fresh1 = 0;

        foreach (string ingredient in availableIngredientIDs)
        {
            long id = long.Parse(ingredient);
            foreach (string range in freshIngredientIDRanges)
            {
                if (id >= long.Parse(range.Split('-')[0]) && id <= long.Parse(range.Split('-')[1]))
                {
                    fresh1++;
                    break;
                }
            }
        }

        List<long> freshIngredientIDs = [];

        foreach (string range in freshIngredientIDRanges)
        {
            for (long i = long.Parse(range.Split('-')[0]); i <= long.Parse(range.Split('-')[1]); i++)
            {
                if (freshIngredientIDs.Contains(i))
                    continue;

                freshIngredientIDs.Add(i);
            }
        }
        Console.WriteLine("Part 1: " + fresh1);
        Console.WriteLine("Part 2: " + freshIngredientIDs.Count);
    }
}