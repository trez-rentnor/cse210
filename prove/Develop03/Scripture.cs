class Scripture {
    /// Criteria 2 - Scripture class
    private Reference _reference;
    private List<Word> _words;
    private List<Word> _visibleWords;
    private static Random random = new Random();

    public Scripture(Reference reference, string text) {
        _reference = reference;

        _words = [];
        _visibleWords = [];
        foreach (string substr in text.Split(" ")) {
            Word word = new Word(substr);
            _words.Add(word);
            _visibleWords.Add(word);
        }
    }

    public void Write(bool showHidden = false) {
        /// Criteria 5 - Functionality: Scripture Display
        Console.Write(_reference.Write());
        foreach (Word word in _words) {
            Console.Write(" ");
            Console.Write(word.Write(showHidden));
        }
        Console.WriteLine();
    }

    public void HideWords() {
        /// Criteria 6 - Functionality: Word Hiding
        int hideCount = random.Next(3, 6);

        for (int i = 0; i < hideCount && _visibleWords.Count > 0; i++) {
            Word selected = _visibleWords[random.Next(_visibleWords.Count)];
            selected.Hide();
            _visibleWords.Remove(selected);
        }
    }

    public bool AllHidden() {
        return _visibleWords.Count == 0;
    }
}
