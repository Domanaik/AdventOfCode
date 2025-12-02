using System;
using AdventOfCode._2;

class Program
{
    static bool IsFirstHalfEqualToSecondHalf(long iNumber)
    {
        string sNumber = iNumber.ToString();

        if (sNumber.Length % 2 != 0)
        {
            return false;
        }

        int length = sNumber.Length / 2;

        return sNumber[..length] == sNumber[length..];
    }

    static bool IsPatternRepeated(long iNumber)
    {
        string sNumber = iNumber.ToString();

        for (int length = 1; length <= sNumber.Length / 2; length++)
        {
            if (sNumber.Length % length != 0)
                continue;

            string remainingPart = sNumber[..length];
            bool IsNotRepeated = true;

            for (int position = 0; position < sNumber.Length; position += length)
            {
                if (sNumber.Substring(position, length) != remainingPart)
                {
                    IsNotRepeated = false;
                    break;
                }
            }

            if (IsNotRepeated)
                return true;
        }

        return false;
    }

    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(',');
        long sumInvalidIds = 0;
        long sumRepeatedIds = 0;

        foreach (string line in inputData)
        {
            long start = long.Parse(line.Split('-')[0]);
            long end = long.Parse(line.Split('-')[1]);

            for (long i = start; i <= end; i++)
            {
                if (IsFirstHalfEqualToSecondHalf(i))
                {
                    sumInvalidIds += i;
                }

                if (IsPatternRepeated(i))
                {
                    sumRepeatedIds += i;
                }
            }
        }
        Console.WriteLine("Part 1: " + sumInvalidIds);
        Console.WriteLine("Part 2: " + sumRepeatedIds);
    }
}