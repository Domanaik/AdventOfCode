using AdventOfCode._1;

class Program
{
    static void Main(string[] args)
    {
        string inputData = Input.GetInput();

        int[] left = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(line => int.Parse(line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)[0])).ToArray();
        int[] right = inputData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(line => int.Parse(line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)[1])).ToArray();
        Array.Sort(left);
        Array.Sort(right);

        int totalDistance = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
        Console.WriteLine(totalDistance);

        int similarityScore = left.Select(value => value * right.Count(r => r == value)).Sum();
        Console.WriteLine(similarityScore);
    }
}