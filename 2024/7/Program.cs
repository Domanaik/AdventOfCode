using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Threading.Tasks.Dataflow;
using AdventOfCode._7;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetInput().Split(Environment.NewLine);

        long totalCalibrationResult = 0;
        const string operators = "+*|";

        foreach (string line in inputData)
        {
            string[] parts = line.Split(':');
            long result = long.Parse(parts[0]);
            int[] numbers = Array.ConvertAll(parts[1].Trim().Split(' '), int.Parse);

            if (TestIfPossible(result, numbers, 0, numbers[0]))
            {
                totalCalibrationResult += result;
            }
        }

        static bool TestIfPossible(long result, int[] numbers, int index, long currentResult)
        {
            if (index == numbers.Length - 1)
            {
                return currentResult == result;
            }

            if (currentResult > result)
            {
                return false;
            }

            foreach (char op in operators)
            {
                int nextNumber = numbers[index + 1];
                long newResult = op switch
                {
                    '+' => currentResult + nextNumber,
                    '*' => currentResult * nextNumber,
                    _ => currentResult * (long)Math.Pow(10, (int)Math.Floor(Math.Log10(nextNumber) + 1)) + nextNumber
                };

                if (TestIfPossible(result, numbers, index + 1, newResult))
                {
                    return true;
                }
            }

            return false;
        }

        Console.WriteLine(totalCalibrationResult);
    }
}