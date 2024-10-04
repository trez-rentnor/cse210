class Word {
    /// Criteria 3 - Word class
    private string _text;
    private bool _hidden;

    public Word(string word) {
        _text = word;
        _hidden = false;
    }

    public void Hide() {
        _hidden = true;
    }

    public string Write(bool showHidden = false) {
        if (_hidden && !showHidden) {
            return new String('_', _text.Length);
        } else {
            return _text;
        }
    }
}