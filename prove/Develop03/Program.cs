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
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");

        /// Criteria 7 - Functionality: Program Termination
        if (Console.ReadLine().ToLower() == "quit") {
            return false;
        }

        if (_scripture.AllHidden()) {
            return false;
        }

        _scripture.HideWords();

        return true;
    }
}

class Scripture {
    /// Criteria 2 - Scripture class
    Reference _reference;
    List<Word> _words;
    List<Word> _visibleWords;
    static Random random = new Random();

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

    public void Write() {
        /// Criteria 5 - Functionality: Scripture Display
        Console.Write(_reference.Display());
        foreach (Word word in _words) {
            Console.Write(" ");
            Console.Write(word.Display());
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

class Reference {
    /// Criteria 4 - Reference class
    string _reference;

    public Reference(string book, string chapter, string beginVerse, string endVerse) :
        this(book, chapter, $"{beginVerse}-${endVerse}") {
    }

    public Reference(string book, string chapter, string verse) {
        _reference = $"{book} {chapter}:{verse}";
    }

    public string Display() {
        return _reference;
    }
}

class Word {
    /// Criteria 3 - Word class
    string _text;
    bool _hidden;

    public Word(string word) {
        _text = word;
        _hidden = false;
    }

    public void Hide() {
        _hidden = true;
    }

    public string Display() {
        if (_hidden) {
            return new String('_', _text.Length);
        } else {
            return _text;
        }
    }
}