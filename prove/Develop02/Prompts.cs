
using System.Collections.ObjectModel;

class Prompts {
    /// <summary>
    ///  Criteria 5: Functionality: Prompt Generation
    /// </summary>

    static readonly ReadOnlyCollection<string> prompts = new ReadOnlyCollection<string>(
        [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "How did I help somebody else today?",
            "What am I grateful for today"
        ]);

    static public string Get() {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}