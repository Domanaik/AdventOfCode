using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] lines = File.ReadAllLines("D:\\GitHub\\AdventOfCode\\2024\\1\\input.txt");
            int[] left = lines.Select(line => int.Parse(line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)[0])).ToArray();
            int[] right = lines.Select(line => int.Parse(line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)[1])).ToArray();
            Array.Sort(left);
            Array.Sort(right);

            int totalDistance = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
            Console.WriteLine(totalDistance);

            int similarityScore = left.Select(value => value * right.Count(r => r == value)).Sum();
            Console.WriteLine(similarityScore);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}