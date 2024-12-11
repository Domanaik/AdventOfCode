using AdventOfCode._11;

class Program
{
    static void Main(string[] args)
    {
        List<long> inputData = Input.GetSample2().Split(' ').Select(long.Parse).ToList();

        List<long> newStoneList = [];

        int blinkTimes = 25;

        for (int i = 0; i < blinkTimes; i++)
        {
            Console.WriteLine($@"{i} of {blinkTimes}");
            inputData = ChangeStoneAtBlink(inputData);
        }

        Console.WriteLine(inputData.Count);
    }

    static List<long> ChangeStoneAtBlink(List<long> stoneList)
    {
        List<long> newStoneList = [];

        foreach (long stone in stoneList)
        {
            string stoneNumber = stone.ToString();
            Console.Write(stone);

            if (stone == 0)
            {
                newStoneList.Add(1);
                Console.WriteLine(" => 1 (Rule 1)");
            }
            else
            {
                int numDigits = (int)Math.Floor(Math.Log10(stone) + 1);
                if (numDigits % 2 == 0)
                {
                    long divisor = (int)Math.Pow(10, numDigits / 2);
                    newStoneList.Add(stone / divisor);
                    newStoneList.Add(stone % divisor);
                    Console.WriteLine($@" => {stone / divisor} & {stone % divisor} (Rule 2)");
                }
                else
                {
                    newStoneList.Add(stone * 2024);
                    Console.WriteLine($@" => {stone * 2024} (Rule 3)");
                }
            }
        }

        return newStoneList;
    }
}