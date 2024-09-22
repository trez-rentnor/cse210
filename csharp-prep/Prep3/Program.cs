using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int target = rand.Next(101);
        int guess;

        do {
            Console.Write("What is your guess? ");
            string response = Console.ReadLine();
            int.TryParse(response, out guess);

            if (guess < target) {
                Console.WriteLine("Higher");
            } else if (guess > target) {
                Console.WriteLine("Lower");
            }
        } while (guess != target);

        Console.WriteLine("You guessed it!");
    }
}