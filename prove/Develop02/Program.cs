using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class Program
{
    Journal journal = new Journal();

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

        journal.AddEntry(journalEntry);
    }

    void DisplayJournal() {
        /// <summary>
        ///  Criteria 4: Functionality: Journal Display
        /// </summary>
        foreach (JournalEntry entry in journal.GetEntries()) {
            Console.WriteLine(entry.DisplayFormat());
        }
    }

    void SaveJournal() {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        journal.Save(filename);
    }

    void LoadJournal() {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        journal = Journal.Load(filename);
    }
}

class Journal {
    /// <summary>
    ///  Criteria 1: Journal abstration
    /// </summary>
    List<JournalEntry> _journalEntries;

    public Journal(List<JournalEntry> entries = null) {
        entries = entries ?? new List<JournalEntry>();
        _journalEntries = entries;
    }

    public void AddEntry(JournalEntry entry) {
        _journalEntries.Add(entry);
    }

    public List<JournalEntry> GetEntries() {
        return _journalEntries;
    }

    public void Save(string filename) {
        /// <summary>
        ///  Criteria 6: Functionality: Saving
        /// </summary>
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            foreach (JournalEntry entry in _journalEntries) {
                outputFile.WriteLine(entry.SaveFormat());
            }
        }
    }

    public static Journal Load(string filename) {
        /// <summary>
        ///  Criteria 7: Functionality: Loading
        /// </summary>

        List<string> lines = new List<string>(System.IO.File.ReadAllLines(filename));
        List<JournalEntry> entries = lines.ConvertAll(
            new Converter<string, JournalEntry>(JournalEntry.ParseLine)
        );

        return new Journal(entries);
    }
}

class JournalEntry {
    /// <summary>
    ///  Criteria 2: Entry abstration
    /// </summary>
    string _entry;
    string _prompt;
    DateTime _date;

    public JournalEntry(DateTime date, string prompt, string entry) {
        _date = date;
        _prompt = prompt;
        _entry = entry;
    }

    public string DisplayFormat() {
        return $"Date: {_date:M/d/yyyy} - Prompt: {_prompt}\n{_entry}\n";
    }

    public string SaveFormat() {
        return $"{_date:M/d/yyyy}|{_prompt}|{_entry}";
    }

    public static JournalEntry ParseLine(string line) {
        string[] fields = line.Split("|");
        DateTime date = DateTime.Parse(fields[0]);
        return new JournalEntry(date, fields[1], fields[2]);
    }
}

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