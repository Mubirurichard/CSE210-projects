using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt inspired this month?",
            "Who are some of your personal heroes?",
            "What are things that make you happy?",
            "What are your greatest accomplishments?",
            "What are you grateful for today?",
            "Who has positively impacted your life?",
            "What are your favorite memories from this year?"
        };

        private int _itemCount;

        public ListingActivity()
            : base("Listing",
                  "This activity will help you reflect on the good things in your life " +
                  "by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            Console.Clear();
            
            // Select and display a random prompt
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            
            Console.WriteLine("List as many responses as you can to the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");
            
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            
            Console.WriteLine();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            
            _itemCount = 0;
            List<string> items = new List<string>();
            
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                    _itemCount++;
                }
                
                // Show time remaining
                int timeLeft = (int)(endTime - DateTime.Now).TotalSeconds;
                if (timeLeft > 0)
                {
                    Console.WriteLine($"Time remaining: {timeLeft} seconds");
                }
            }
            
            Console.WriteLine($"\nYou listed {_itemCount} items!");
            
            // Show a summary of items
            if (_itemCount > 0)
            {
                Console.WriteLine("\nHere's what you listed:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            
            DisplayEndingMessage();
        }
    }
}