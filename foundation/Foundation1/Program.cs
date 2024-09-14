using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = BuildVideoList();
        /// Criteria 6 Function: Object Use
        foreach (Video video in videos) {
            video.Display();
            Console.WriteLine();
        }
    }

    static List<Video> BuildVideoList() {
        /// Criteria 5 - Functionality: Object creation
        return new List<Video> {
            new Video(
                "Watch me eat 5 whole watermelons!",
                "skibidiboy72",
                354.8f,
                new List<Comment> {
                    new Comment("sagetfan", "No way! I can't believe this is real."),
                    new Comment("luke", "One time I ate 50 hard boiled eggs."),
                    new Comment("mark", "This is fake.")
                }
            ),
            new Video(
                "Inside Taylor Swift's Hidden Agenda",
                "Enter The Illuminati",
                129.3f,
                new List<Comment> {
                    new Comment("swiftie392", "No way!  She just wants to sing!"),
                    new Comment("drinkingandknowingthings", "I knew her goodie goodie image was too good to be true."),
                    new Comment("martysminion", "Buy bitcoin here!!!!!!!")
                }
            ),
            new Video(
                "Why 1x1=2",
                "terencehoward",
                50.6f,
                new List<Comment> {
                    new Comment("flatearther3", "Why don't they teach this in schools!"),
                    new Comment("painteater1", "This makes perfect sense."),
                    new Comment("mathguy_phd", "Wha?  I don't know where to begin.")
                }
            )
        };
    }
}

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

class Comment {
    /// Criteria 2
    string _author;
    string _text;

    public Comment(string author, string text) {
        _author = author;
        _text = text;
    }

    public void Display() {
        Console.WriteLine($"{_author} - {_text}");
    }
}