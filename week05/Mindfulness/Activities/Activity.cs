using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    // Base class for all mindfulness activities
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected static int _totalActivities = 0;
        protected static int _totalSeconds = 0;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Common starting message for all activities
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity!");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int duration))
            {
                _duration = duration;
                _totalSeconds += duration;
            }
            else
            {
                _duration = 30; // Default duration
            }
            
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(5);
        }

        // Common ending message for all activities
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
            
            _totalActivities++;
        }

        // Show spinner animation
        protected void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string>
            {
                "|",
                "/",
                "-",
                "\\",
                "|",
                "/",
                "-",
                "\\"
            };

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            int i = 0;
            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
                
                i++;
                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
            Console.WriteLine();
        }

        // Show countdown timer
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Show growing/shrinking text for breathing animation
        protected void ShowBreathingAnimation(string text, int seconds, bool breatheIn)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            
            int maxSize = breatheIn ? 30 : 10;
            int currentSize = breatheIn ? 1 : maxSize;
            int increment = breatheIn ? 1 : -1;
            
            while (DateTime.Now < endTime)
            {
                Console.Clear();
                Console.WriteLine($"{text}\n");
                
                // Create visual representation of breath
                string breathVisual = new string('=', currentSize);
                Console.WriteLine($"[{breathVisual}]");
                
                // Show countdown
                int remaining = (int)(endTime - DateTime.Now).TotalSeconds + 1;
                Console.WriteLine($"\n{remaining} seconds remaining");
                
                Thread.Sleep(100);
                
                if (breatheIn && currentSize < maxSize)
                    currentSize += increment;
                else if (!breatheIn && currentSize > 1)
                    currentSize += increment;
            }
        }

        // Abstract method that must be implemented by derived classes
        public abstract void Run();

        // Expose duration so callers don't need reflection
        public int Duration
        {
            get { return _duration; }
        }

        // Static method to show activity statistics
        public static void DisplayStatistics()
        {
            Console.WriteLine($"\n=== Activity Statistics ===");
            Console.WriteLine($"Total activities completed: {_totalActivities}");
            Console.WriteLine($"Total time spent: {_totalSeconds} seconds");
            Console.WriteLine($"Average session length: {(_totalActivities > 0 ? _totalSeconds / _totalActivities : 0)} seconds");
            Console.WriteLine("==========================\n");
        }
    }
}