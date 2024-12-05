using AdventOfCode._5;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetSample().Split(Environment.NewLine + Environment.NewLine);
        string rulesSection = inputData[0];
        string updatesSection = inputData[1];

        List<(int First, int Second)> rules = [];
        foreach (string line in rulesSection.Split(Environment.NewLine))
        {
            int[] parts = line.Split('|').Select(int.Parse).ToArray();
            rules.Add((parts[0], parts[1]));
        }

        List<List<int>> updates = updatesSection.Split(Environment.NewLine).Select(line => line.Split(',').Select(int.Parse).ToList()).ToList();

        Console.WriteLine("Rules:");
        foreach ((int First, int Second) in rules)
        {
            Console.WriteLine($"{First} -> {Second}");
        }

        Console.WriteLine("\nUpdates:");
        foreach (List<int> update in updates)
        {
            Console.WriteLine(string.Join(", ", update));
        }
    }
}