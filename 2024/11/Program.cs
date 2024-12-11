using AdventOfCode._11;

class Program
{
    static void Main(string[] args)
    {
        List<int> inputData = Input.GetInput().Split(' ').Select(int.Parse).ToList();

        int blinkTimes = 75;
        List<long> finalStones = [];

        foreach (int stone in inputData)
        {
            List<long> stonesAfterAllBlinks = [stone];

            for (int i = 0; i < blinkTimes; i++)
            {
                Console.WriteLine($@"({i + 1}/{blinkTimes})");
                List<long> transformedStones = [];

                foreach (long currentStone in stonesAfterAllBlinks)
                {
                    transformedStones.AddRange(ApplyBlink(currentStone));
                }

                stonesAfterAllBlinks = transformedStones;
            }

            finalStones.AddRange(stonesAfterAllBlinks);
        }

        Console.WriteLine($"Total stones after {blinkTimes} blinks: {finalStones.Count}");
    }

    static List<long> ApplyBlink(long stone)
    {
        //Console.Write($@" {stone}");
        List<long> newStones = [];
        int numDigits = (int)Math.Floor(Math.Log10(stone) + 1);

        if (stone == 0)
        {
            newStones.Add(1);
            //Console.WriteLine(" => 1 (Rule 1)");
        }
        else if (numDigits % 2 == 0)
        {
            long divisor = (long)Math.Pow(10, numDigits / 2);
            newStones.Add(stone / divisor);
            newStones.Add(stone % divisor);
            //Console.WriteLine($@" => {stone / divisor} & {stone % divisor} (Rule 2)");
        }
        else
        {
            newStones.Add(stone * 2024);
            //Console.WriteLine($@" => {stone * 2024} (Rule 3)");
        }

        return newStones;
    }
}