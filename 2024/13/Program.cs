using AdventOfCode._13;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Input.GetSample().Split(Environment.NewLine + Environment.NewLine);

        List<(int, (int x, int y))> clawMachines = [];

        foreach (var block in inputData)
        {
            var lines = block.Split(Environment.NewLine);

            var buttonA = ParseCoordinates(lines[0]);
            var buttonB = ParseCoordinates(lines[1]);
            var prize = ParseCoordinates(lines[2]);

            Console.WriteLine($"Button A: X+{buttonA.X}, Y+{buttonA.Y}");
            Console.WriteLine($"Button B: X+{buttonB.X}, Y+{buttonB.Y}");
            Console.WriteLine($"Prize: X={prize.X}, Y={prize.Y}\n");
        }
    }

    static (int X, int Y) ParseCoordinates(string line)
    {
        var parts = line.Split(',');
        int x = int.Parse(parts[0].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        int y = int.Parse(parts[1].Split(['+', '='], StringSplitOptions.RemoveEmptyEntries)[1]);
        return (x, y);
    }
}