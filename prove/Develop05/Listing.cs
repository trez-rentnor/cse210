class Listing : Activity {
    /// Criteria 2: Principle: Inheritence Heirarchy
    public Listing() :
        base("Listing", "This activity will help you reflect on the good things in your life by having" +
            "you list as many things as you can in a certain area.") { }

    private Random _random = new Random();

    private List<String> _prompts = new List<String> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    protected override void DoActivity(int length) {
        DateTime endTime = DateTime.Now.AddSeconds(length);

        Console.WriteLine("List as many resources you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[_random.Next(_prompts.Count)]} ---");
        Console.Write("You may begin in : ");
        CountDown(5);
        Console.WriteLine();

        int answerCount = 0;
        while (DateTime.Now <= endTime) {
            Console.Write("> ");
            Console.ReadLine();
            answerCount++;
        }

        Console.WriteLine($"You listed {answerCount} items!");
    }
}