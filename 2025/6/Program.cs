using System.Data.SqlTypes;
using System.Security.Principal;
using AdventOfCode._6;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);
        int inputDataLength = inputData[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        List<long[]> numbers = [];
        foreach (string line in inputData)
        {
            string[] strNumbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            long[] iNumbers = Array.ConvertAll<string, long>(strNumbers, s => long.TryParse(s, out var i) ? i : 0); // Try parsing everything to long, we handle the * and + later
            numbers.Add(iNumbers);
        }

        numbers.RemoveAt(numbers.Count - 1); // Remove the 0s from TryParsing the * and +

        long grandTotal = 0;

        for (int i = 0; i < inputDataLength; i++)
        {
            List<long> individualProblem = [];
            for (int j = 0; j < numbers.Count; j++)
            {
                individualProblem.Add(numbers[j][i]);
            }

            string operation = inputData[inputData.Length - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[i];
            long tmp = 0;

            if (operation == "*")
            {
                tmp++;
                for (int x = 0; x < individualProblem.Count; x++)
                {
                    tmp *= individualProblem[x];
                }
            }
            else
            {
                for (int x = 0; x < individualProblem.Count; x++)
                {
                    tmp += individualProblem[x];
                }
            }

            grandTotal += tmp;
        }

        Console.WriteLine("Part 1: " + grandTotal);
    }
}