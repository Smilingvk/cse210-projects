using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine(new string('-', 40));
    }
}


class Program
{
    static void Main(string[] args)
    {        List<Video> videos = new List<Video>();

        Video video1 = new Video("Intro to C#", "Jane Doe", 300);
        video1.AddComment(new Comment("Alice", "Great intro!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Loved it!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced OOP", "John Smith", 600);
        video2.AddComment(new Comment("Daniel", "Well explained."));
        video2.AddComment(new Comment("Eva", "Please do one on interfaces!"));
        video2.AddComment(new Comment("Frank", "Subbed!"));
        videos.Add(video2);

        Video video3 = new Video("Debugging in Visual Studio", "Mary Johnson", 450);
        video3.AddComment(new Comment("Grace", "Super useful!"));
        video3.AddComment(new Comment("Henry", "Clear and concise."));
        video3.AddComment(new Comment("Isabel", "More content please!"));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }
}