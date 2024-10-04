using System;

class Program
{
    Scripture _scripture = new Scripture(
        new Reference("Moses", "1", "39"),
        "For behold, this is my work and my glory — to bring to pass the immortality and eternal life of man."
    );

    static void Main(string[] args)
    {
        Program program = new Program();

        while (program.WriteScripture()) { }
    }

    bool WriteScripture() {
        Console.Clear();
        _scripture.Write();
        Console.WriteLine();

        /// Criteria 10 - To exceed requirements, the user can type "flash" to view
        /// the entire scripture for a short time
        Console.WriteLine("Press enter to continue, type 'quit' to finish, or type 'flash' to see scripture:");

        string response = Console.ReadLine().ToLower();

        if (response == "flash") {
            Console.Clear();
            _scripture.Write(true);
            Thread.Sleep(500);
            return true;
        }

        /// Criteria 7 - Functionality: Program Termination
        if (response == "quit") {
            return false;
        }

        if (_scripture.AllHidden()) {
            return false;
        }

        _scripture.HideWords();

        return true;
    }
}
