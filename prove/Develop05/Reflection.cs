
class Reflection : Activity {
    /// Criteria 2: Principle: Inheritence Heirarchy
    public Reflection() :
        base("Reflection", 
            "This activity will help you reflect on times in your life when you have shown " +
            "strength and resilience. This will help you recognize the power you have and " +
            "how you can use it in other aspects of your life.") { }

    private Random _random = new Random();

    private List<String> _prompts = new List<String> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<String> _questions = new List<String> {
        "Why was this experience meaningful to you?", 
        "Have you ever done anything like this before?", 
        "How did you get started?", 
        "How did you feel when it was complete?", 
        "What made this time different than other times when you were not as successful?", 
        "What is your favorite thing about this experience?", 
        "What could you learn from this experience that applies to other situations?", 
        "What did you learn about yourself through this experience?", 
        "How can you keep this experience in mind in the future?" 
    };

    protected override void DoActivity(int length) {
        DateTime endTime = DateTime.Now.AddSeconds(length);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($" --- {_prompts[_random.Next(_prompts.Count)]} ---");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.Clear();

        while (DateTime.Now <= endTime) {
            Console.WriteLine($"> {_questions[_random.Next(_questions.Count)]} ");
            ShowAnimation(15);
        }
    }
}