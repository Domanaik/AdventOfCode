using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] lines = File.ReadAllLines("D:\\GitHub\\AdventOfCode\\2024\\2\\input.txt");
            int[][] reports = lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();

            int safeReports = reports.Count(report => IsSafe(report) || IsSafeable(report));
            Thread.Sleep(9000); // Test if Benchmark is working
            Console.WriteLine(safeReports);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    static bool IsSafe(int[] report)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 0; i < report.Length - 1; i++)
        {
            int diff = report[i] - report[i + 1];

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false;
            }

            if (diff > 0)
            {
                isIncreasing = false;
            }

            if (diff < 0)
            {
                isDecreasing = false;
            }
        }

        return isIncreasing || isDecreasing;
    }

    static bool IsSafeable(int[] report)
    {
        for (int i = 0; i < report.Length; i++)
        {
            int[] newReport = report.Where((_, index) => index != i).ToArray();
            if (IsSafe(newReport))
            {
                return true;
            }
        }
        return false;
    }
}