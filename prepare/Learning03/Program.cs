using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction five = new Fraction(5);
        Fraction threefourths = new Fraction(3, 4);
        Fraction onethird = new Fraction(1, 3);

        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(one.GetDecimalValue());
        Console.WriteLine(five.GetFractionString());
        Console.WriteLine(five.GetDecimalValue());
        Console.WriteLine(threefourths.GetFractionString());
        Console.WriteLine(threefourths.GetDecimalValue());
        Console.WriteLine(onethird.GetFractionString());
        Console.WriteLine(onethird.GetDecimalValue());
    }
}