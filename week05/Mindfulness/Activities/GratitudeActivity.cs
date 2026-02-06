using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class GratitudeActivity : Activity
    {
        private List<string> _gratitudeCategories = new List<string>
        {
            "People you're grateful for",
            "Experiences you're grateful for",
            "Things you own that you're grateful for",
            "Skills or abilities you're grateful for",
            "Places you're grateful for",
            "Lessons you've learned that you're grateful for",
            "Moments of joy you're grateful for",
            "Challenges that made you stronger"
        };

        public GratitudeActivity()
            : base("Gratitude",
                  "This activity helps cultivate gratitude by focusing on specific " +
                  "areas of your life. Research shows gratitude practice increases happiness " +
                  "and reduces stress.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            Console.Clear();
            Console.WriteLine("Gratitude Practice\n");
            Console.WriteLine("For the next few minutes, we'll focus on different areas of gratitude.");
            Console.WriteLine("Take a moment to reflect on each category.\n");
            
            ShowSpinner(3);
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            int categoryIndex = 0;
            
            while (DateTime.Now < endTime && categoryIndex < _gratitudeCategories.Count)
            {
                string category = _gratitudeCategories[categoryIndex];
                
                Console.Clear();
                Console.WriteLine($"Category {categoryIndex + 1} of {_gratitudeCategories.Count}");
                Console.WriteLine($"\n--- {category} ---\n");
                
                Console.WriteLine("Take a moment to think about this category...");
                ShowSpinner(5);
                
                Console.WriteLine("\nNow, write down 3 things in this category that you're grateful for:");
                
                List<string> gratitudes = new List<string>();
                for (int i = 1; i <= 3; i++)
                {
                    Console.Write($"{i}. ");
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        gratitudes.Add(item);
                    }
                }
                
                Console.WriteLine("\nTake a moment to appreciate these things...");
                ShowSpinner(3);
                
                categoryIndex++;
                
                // Check if there's time for another category
                if (categoryIndex < _gratitudeCategories.Count && 
                    (endTime - DateTime.Now).TotalSeconds < 30)
                {
                    Console.WriteLine("\nLet's move to the next category...");
                    ShowSpinner(2);
                }
            }
            
            Console.WriteLine("\n★ Gratitude Reflection ★");
            Console.WriteLine("Take a deep breath and reflect on all the things you're grateful for.");
            ShowSpinner(5);
            
            DisplayEndingMessage();
        }
    }
}