class Reference {
    /// Criteria 4 - Reference class
    private string _reference;

    public Reference(string book, string chapter, string beginVerse, string endVerse) :
        this(book, chapter, $"{beginVerse}-${endVerse}") {
    }

    public Reference(string book, string chapter, string verse) {
        _reference = $"{book} {chapter}:{verse}";
    }

    public string Write() {
        return _reference;
    }
}
