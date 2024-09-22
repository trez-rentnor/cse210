using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, square);
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        string response = Console.ReadLine();
        int.TryParse(response, out int result);
        return result;
    }

    static int SquareNumber(int num) {
        return num * num;
    }

    static void DisplayResult(string name, int square) {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}