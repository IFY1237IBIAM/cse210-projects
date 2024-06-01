using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int NumComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos and comments
        Video video1 = new Video("Product Review", "John Doe", 300);
        video1.AddComment(new Comment("Jane Smith", "Great review!"));
        video1.AddComment(new Comment("Bob Johnson", "Agree with the reviewer"));
        video1.AddComment(new Comment("Alice Brown", "Thanks for the info"));

        Video video2 = new Video("Unboxing", "Sarah Lee", 180);
        video2.AddComment(new Comment("Mike Davis", "Love the product design"));
        video2.AddComment(new Comment("Emily Chen", "Nice video"));
        video2.AddComment(new Comment("David Kim", "Want one!"));

        Video video3 = new Video("Tutorial", "Tom Harris", 600);
        video3.AddComment(new Comment("Lily White", "Helpful tutorial"));
        video3.AddComment(new Comment("Sam Brown", "Thanks for sharing"));
        video3.AddComment(new Comment("Hannah Davis", "Well explained"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video and comment information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.NumComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
