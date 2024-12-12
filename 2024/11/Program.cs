using AdventOfCode._11;

class Program
{
    static void Main(string[] args)
    {
        List<int> inputData = Input.GetInput().Split(' ').Select(int.Parse).ToList();

        Dictionary<(long, int), long> cache = [];
        long stonesCount = 0;

        foreach (int stone in inputData)
        {
            stonesCount += ApplyBlink(stone, 75, cache);
        }

        Console.WriteLine(stonesCount);
    }

    static long ApplyBlink(long stone, int blinksLeft, Dictionary<(long, int), long> cache)
    {
        if (cache.TryGetValue((stone, blinksLeft), out var cached))
        {
            return cached;
        }

        if (blinksLeft == 0)
        {
            return 1;
        }

        long stonesCount = 0;
        int numDigits = (int)Math.Floor(Math.Log10(stone) + 1);

        if (stone == 0)
        {
            stonesCount += ApplyBlink(1, blinksLeft - 1, cache);
        }
        else if (numDigits % 2 == 0)
        {
            long divisor = (int)Math.Pow(10, numDigits / 2);
            stonesCount += ApplyBlink(stone / divisor, blinksLeft - 1, cache);
            stonesCount += ApplyBlink(stone % divisor, blinksLeft - 1, cache);
        }
        else
        {
            stonesCount += ApplyBlink(stone * 2024, blinksLeft - 1, cache);
        }

        cache[(stone, blinksLeft)] = stonesCount;

        return stonesCount;
    }
}