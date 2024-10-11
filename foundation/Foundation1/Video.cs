class Video {
    /// Criteria 1
    string _title;
    string _author;
    float _length;

    /// Criteria 3
    List<Comment> _comments;

    public Video(string title, string author, float length, List<Comment> comments = null) {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments ?? [];
    }

    public void AddComment(string author, string text) {
        _comments.Add(new Comment(author, text));
    }

    /// Criteria 4
    public int CommentCount() {
        return _comments.Count;
    }

    public void Display() {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} sec");
        Console.WriteLine($"Total Comments: {CommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments) {
            comment.Display();
        }
    }
}
