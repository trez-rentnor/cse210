
class Breathing : Activity {
    /// Criteria 2: Principle: Inheritence Heirarchy
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