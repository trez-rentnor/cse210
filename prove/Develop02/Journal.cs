
class Journal {
    /// <summary>
    ///  Criteria 1: Journal abstration
    /// </summary>
    List<JournalEntry> _journalEntries;
    bool _dirty;

    public Journal(List<JournalEntry> entries = null) {
        entries = entries ?? new List<JournalEntry>();
        _journalEntries = entries;
        _dirty = false;
    }

    public void AddEntry(JournalEntry entry) {
        _journalEntries.Add(entry);
        _dirty = true;
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
        _dirty = false;
    }

    public bool IsDirty() {
        return _dirty;
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
