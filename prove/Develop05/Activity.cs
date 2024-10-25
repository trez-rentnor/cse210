
abstract class Activity {
    /// Criteria 3: Principle: Inheriting Attributes
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description) {
        /// Criteria 1: Principle: Encapsulation
        _name = name;
        _description = description;
    }

    public String GetName() {
        return _name;
    }

    public String GetDescription() {
        return _description;
    }

    ///  Criteria 4: Priniciple: Inheriting Behaviors
    public void RunActivity() {
        // Start Activity
        Console.Clear();
        Console.WriteLine($"Welcome to {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        int.TryParse(Console.ReadLine(), out _duration);
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowAnimation(8);
        Console.WriteLine();

        // Doing the activity is handled by the subclass
        DoActivity(_duration);

        // End Activity
        Console.WriteLine();
        Console.WriteLine("Well Done!");
        ShowAnimation(8);
        Console.WriteLine($"You did another {_duration} seconds of {_name}.");
        ShowAnimation(8);
        Console.Clear();
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