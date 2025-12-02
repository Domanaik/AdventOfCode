using AdventOfCode._1;

class Program
{
    static void Main(string[] args)
    {
        string[] inputData = GetInput().Split(Environment.NewLine);
        int start = 50;
        int password1 = 0;
        int password2 = 0;

        foreach (string line in inputData)
        {
            int value = int.Parse(line[1..]);
            if (line[0] == 'R')
            {
                start += value;
                while (start > 99)
                {
                    start -= 100;
                    if (start > 0)
                        password2++;
                }
            }
            else
            {
                if (start == 0)
                    password2--;
                start -= value;
                while (start < 0)
                {
                    start += 100;
                    password2++;
                }
            }
            if (start == 0)
                password1++;
        }
        password2 += password1;
            
        Console.WriteLine("Part 1: " + password1);
        Console.WriteLine("Part 2: " + password2);
    }
}
