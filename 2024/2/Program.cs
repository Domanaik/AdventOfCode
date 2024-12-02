using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string filePath;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            filePath = "..\\..\\..\\input.txt";
        }
        else
        {
            filePath = "../../../input.txt";
        }

        string[] lines = File.ReadAllLines(filePath);
        int[][] reports = lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();

        int safeReports = reports.Count(report => IsSafe(report) || IsSafeable(report));
        Thread.Sleep(8000); // Test if Benchmark is working
        Console.WriteLine(safeReports);
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