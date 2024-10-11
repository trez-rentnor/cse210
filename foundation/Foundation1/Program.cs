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