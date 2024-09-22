using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int newNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int.TryParse(input, out newNumber);
            if (newNumber != 0) {
                numbers.Add(newNumber);
            }
        } while (newNumber != 0);

        int sum = 0;
        int max = 0;
        foreach (int number in numbers) {
            sum += number;
            if (number > max) {
                max = number;
            }
        }
        float average = sum / (float)numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}