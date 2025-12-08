using AdventOfCode._3;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetSample().Split(Environment.NewLine);
        long totalJoltage1 = 0;
        long totalJoltage2 = 0;

        foreach (string line in inputData)
        {
            long highest1 = 0;

            for (int i = 0; i < line.Length - 1; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    long possibleJoltage = (line[i] - '0') * 10 + (line[j] - '0');

                    if (possibleJoltage > highest1)
                    {
                        highest1 = possibleJoltage;
                    }
                }
            }

            totalJoltage1 += highest1;

            long highest2 = 0;

            for (int i = 0; i < line.Length - 12; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    long possibleJoltage = (line[i] - '0') * 10 + (line[j] - '0');

                    if (possibleJoltage > highest2)
                    {
                        highest2 = possibleJoltage;
                    }
                }
            }

            totalJoltage2 += highest2;
        }

        Console.WriteLine("Part 1: " + totalJoltage1);
        Console.WriteLine("Part 2: " + totalJoltage2);
    }
}