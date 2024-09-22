using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string response = Console.ReadLine();
        float.TryParse(response, out float percentage);

        string grade = "F";

        if (percentage >= 90.0) {
            grade = "A";
        } else if (percentage >= 80.0) {
            grade = "B";
        } else if (percentage >= 70.0) {
            grade = "C";
        } else if (percentage >= 60.0) {
            grade = "D";
        }

        Console.WriteLine($"Your grade is {grade}.");

        if (percentage >= 70.0) {
            Console.WriteLine("Congratulations! You passed.");
        } else {
            Console.WriteLine("Sorry! You failed.");
        }
    }
}