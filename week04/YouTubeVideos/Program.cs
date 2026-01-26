using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("== YouTube Video Tracker ==\n");
        
        // Create list to store videos
        List<Video> videos = new List<Video>();
        
        // Create first video
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 1200);
        video1.AddComment(new Comment("Alice", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("Bob", "I learned so much from this."));
        video1.AddComment(new Comment("Charlie", "Could you make one about inheritance?"));
        video1.AddComment(new Comment("Diana", "Clear explanations, thanks!"));
        videos.Add(video1);
        
        // Create second video
        Video video2 = new Video("Cooking Pasta Carbonara", "ChefJohn", 600);
        video2.AddComment(new Comment("Emma", "Looks delicious!"));
        video2.AddComment(new Comment("Frank", "I tried this recipe, turned out great!"));
        video2.AddComment(new Comment("Grace", "What type of cheese do you recommend?"));
        videos.Add(video2);
        
        // Create third video
        Video video3 = new Video("Guitar Basics for Beginners", "MusicPro", 1800);
        video3.AddComment(new Comment("Henry", "Perfect for beginners like me."));
        video3.AddComment(new Comment("Ivy", "The chord transitions are explained well."));
        video3.AddComment(new Comment("Jack", "More songs please!"));
        video3.AddComment(new Comment("Karen", "The strumming patterns are so helpful."));
        videos.Add(video3);
        
        // Create fourth video (bonus)
        Video video4 = new Video("Morning Yoga Routine", "YogaWithMe", 900);
        video4.AddComment(new Comment("Leo", "This is my daily routine now!"));
        video4.AddComment(new Comment("Mia", "Perfect way to start the day."));
        video4.AddComment(new Comment("Noah", "Great for flexibility."));
        videos.Add(video4);
        
        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("════════════════════════════════════════");
            Console.WriteLine(video.GetVideoInfo());
            Console.WriteLine("\nComments:");
            
            foreach (string comment in video.GetAllComments())
            {
                Console.WriteLine($"  • {comment}");
            }
            
            Console.WriteLine(); // Blank line for separation
        }
        
        Console.WriteLine("════════════════════════════════════════");
        Console.WriteLine($"Total Videos Tracked: {videos.Count}");
    }
}