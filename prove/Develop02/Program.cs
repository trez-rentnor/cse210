class Program
{
    Journal _journal = new Journal();

    static void Main (string[] args) {
        Program program = new Program();

        Console.WriteLine("Welcome to the Journal Program!");

        bool quit = false;
        while (!quit) {
            switch (program.GetResponse()) {
                case "1":
                    program.WriteEntry();
                    break;
                case "2":
                    program.DisplayJournal();
                    break;
                case "3":
                    program.LoadJournal();
                    break;
                case "4":
                    program.SaveJournal();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }

        // Criteria 10: Exceed core requirements
        // If the user hasn't saved their journal prompt them to do so.
        if (program.PromptUnsaved()) {
            program.SaveJournal();
        }
    }

    string GetResponse() {
        Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");

        return Console.ReadLine();
    }

    void WriteEntry() {
        /// <summary>
        ///  Criteria 3: Functionality: Journal Writing
        /// </summary>
        string prompt = Prompts.Get();
        Console.WriteLine(prompt);
        Console.Write("> ");

        string entry = Console.ReadLine();

        JournalEntry journalEntry = new JournalEntry(DateTime.Now, prompt, entry);

        _journal.AddEntry(journalEntry);
    }

    void DisplayJournal() {
        /// <summary>
        ///  Criteria 4: Functionality: Journal Display
        /// </summary>
        foreach (JournalEntry entry in _journal.GetEntries()) {
            Console.WriteLine(entry.DisplayFormat());
        }
    }

    void SaveJournal() {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        _journal.Save(filename);
    }

    void LoadJournal() {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        _journal = Journal.Load(filename);
    }

    bool PromptUnsaved() {
        if (!_journal.IsDirty())
            return false;

        Console.WriteLine("You haven't saved your journal. Save now? (Y/n) ");
        string response = Console.ReadLine();
        if (response.ToLower() == "n") {
            return false;
        }

        return true;
    }
}