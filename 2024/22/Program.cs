using AdventOfCode._22;

class Program
{
    static void Main(string[] args)
    {
        List<int> inputData = Input.GetInput().Split(Environment.NewLine).Select(int.Parse).ToList();
        List<long> buyers = [];

        foreach (var buyer in inputData)
        {
            long secretNumber = buyer;

            for (int i = 0; i < 2000; i++)
            {
                secretNumber = NextSecretNumber(secretNumber);
            }

            buyers.Add(secretNumber);
        }

        Console.WriteLine(buyers.Sum());

    }

    static long NextSecretNumber(long secretNumber)
    {
        /* Calculate the result of multiplying the secret number by 64. Then, mix 
        this result into the secret number.Finally, prune the secret number. */
        secretNumber = Prune(Mix(secretNumber, secretNumber *= 64));

        /* Calculate the result of dividing the secret number by 32. Round the 
        result down to the nearest integer.Then, mix this result into the 
        secret number.Finally, prune the secret number. */
        secretNumber = Prune(Mix(secretNumber, secretNumber /= 32));

        /* Calculate the result of multiplying the secret number by 2048. Then, 
        mix this result into the secret number.Finally, prune the secret number. */
        secretNumber = Prune(Mix(secretNumber, secretNumber *= 2048));

        return secretNumber;
    }

    static long Mix(long secretNumber, long givenValue)
    {
        return secretNumber ^ givenValue;
    }

    static long Prune(long secretNumber)
    {
        return secretNumber % 16777216;
    }
}