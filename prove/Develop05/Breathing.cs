
class Breathing : Activity {
    /// Criteria 2: Principle: Inheritence Heirarchy
    public Breathing() :
        base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) {
    }

    protected override void DoActivity(int length) {
        /// Exceeding requirements - Shows a more complex animation
        DateTime endTime = DateTime.Now.AddSeconds(length);
        List<String> frames = new List<String> {
            ".     ",
            ".~    ",
            ".~*   ",
            ".~*~  ",
            ".~*~. ",
            " ~*~. ",
            "  *~. ",
            "   ~. ",
            "    . ",
            "      "
        };

        while (DateTime.Now <= endTime) {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowAnimation(Math.Min(5, (endTime - DateTime.Now).Seconds + 1), frames: frames);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowAnimation(Math.Min(5, (endTime - DateTime.Now).Seconds + 1), frames: frames);
            Console.WriteLine();
        }
    }
}