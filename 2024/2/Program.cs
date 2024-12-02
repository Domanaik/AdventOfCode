using AdventOfCode._2;

class Program
{
    static void Main(string[] args)
    {
        string inputData = Input.GetInput();

        int[][] reports = inputData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();

        int safeReports = reports.Count(report => IsSafe(report) || IsSafeable(report));

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