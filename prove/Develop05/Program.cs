using System;

class Program
{
    static void Main(string[] args)
    {
        new Breathing().RunActivity();
    }
}

abstract class Activity {
    /// Criteria 3: Principle: Inheriting Attributes
    string _name;
    string _description;
    int _duration;

    public Activity(string name, string description) {
        /// Criteria 1: Principle: Encapsulation
        _name = name;
        _description = description;
    }

    ///  Criteria 4: Priniciple: Inheriting Behaviors
    public void RunActivity() {
        // Start Activity
        Console.WriteLine($"Welcome to {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        int.TryParse(Console.ReadLine(), out _duration);
        Console.WriteLine("Get Ready...");
        ShowAnimation(8);

        // Doing the activity is handled by the subclass
        DoActivity(_duration);

        // End Activity
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        ShowAnimation(8);
        Console.WriteLine($"Congratulations!  You did another {_duration} seconds of {_name}.");
        ShowAnimation(8);
    }

    protected void ShowAnimation(int duration, int delay = 200) {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> frames = new List<string> {"|", "/", "-", "\\"};

        while (true) {
            foreach (string frame in frames) {
                if (DateTime.Now >= endTime) {
                    goto End;
                }

                Console.Write("\r");
                Console.Write(frame);
                Thread.Sleep(delay);
            }
        }

        End:
        Console.Write("\r \r");
    }

    protected void CountDown(int seconds) {
        foreach (int index in Enumerable.Range(0, seconds)) {
            Console.Write(seconds - index);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.Write(" \b");
    }

    protected abstract void DoActivity(int length);
}

class Breathing : Activity
/// Criteria 2: Principle: Inheritence Heirarchy
{
    public Breathing() :
        base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) {
    }

    protected override void DoActivity(int length) {
        DateTime endTime = DateTime.Now.AddSeconds(length);

        while (DateTime.Now <= endTime) {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            CountDown(Math.Min(5, (endTime - DateTime.Now).Seconds + 1));
            Console.WriteLine();
            Console.Write("Breathe out... ");
            CountDown(Math.Min(7, (endTime - DateTime.Now).Seconds + 1));
            Console.WriteLine();
        }
    }
}

class Reflection : Activity
/// Criteria 2: Principle: Inheritence Heirarchy
{
    public Reflection(string description) :
        base("Reflection", description) {

    }

    protected override void DoActivity(int length) {

    }
}

class Listing : Activity
/// Criteria 2: Principle: Inheritence Heirarchy
{
    public Listing(string description) :
        base("Listing", description) {

    }

    protected override void DoActivity(int length) {

    }
}