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
