using AdventOfCode._11;

class Program
{
    static void Main(string[] args)
    {
        List<int> inputData = Input.GetSample1().Split(' ').Select(int.Parse).ToList();

        int blinkTimes = 6;
        Dictionary<(long, int), List<long>> cache = [];
        List<long> finalStones = [];

        foreach (int stone in inputData)
        {
            finalStones.AddRange(ApplyBlink(stone, blinkTimes, cache));
        }

        Console.WriteLine($"Total stones after {blinkTimes} blinks: {finalStones.Count}");
    }

    static List<long> ApplyBlink(long stone, int blinksLeft, Dictionary<(long, int), List<long>> cache)
    {
        if (cache.TryGetValue((stone, blinksLeft), out var cached))
        {
            return cached;
        }

        if (blinksLeft == 0)
        {
            return [stone];
        }

        List<long> newStones = [];
        int numDigits = (int)Math.Floor(Math.Log10(stone) + 1);

        if (stone == 0)
        {
            newStones.AddRange(ApplyBlink(1, blinksLeft - 1, cache));
        }
        else if (numDigits % 2 == 0)
        {
            long divisor = (long)Math.Pow(10, numDigits / 2);
            newStones.AddRange(ApplyBlink(stone / divisor, blinksLeft - 1, cache));
            newStones.AddRange(ApplyBlink(stone % divisor, blinksLeft - 1, cache));
        }
        else
        {
            newStones.AddRange(ApplyBlink(stone * 2024, blinksLeft - 1, cache));
        }

        cache[(stone, blinksLeft)] = newStones;

        return newStones;
    }
}