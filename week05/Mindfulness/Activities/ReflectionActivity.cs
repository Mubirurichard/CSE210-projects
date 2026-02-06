using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a significant challenge.",
            "Think of a time when you made someone's day better.",
            "Think of a time when you learned something important about yourself."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "Who was involved in this experience and how did they contribute?",
            "What would you do differently if you could relive this experience?",
            "How has this experience shaped who you are today?"
        };

        private List<string> _usedQuestions = new List<string>();

        public ReflectionActivity()
            : base("Reflection",
                  "This activity will help you reflect on times in your life when you have shown " +
                  "strength and resilience. This will help you recognize the power you have and " +
                  "how you can use it in other aspects of your life.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            Console.Clear();
            
            // Select and display a random prompt
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            
            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine($"--- {prompt} ---\n");
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            
            Console.Clear();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            
            // Reset used questions if all have been used
            if (_usedQuestions.Count >= _questions.Count)
            {
                _usedQuestions.Clear();
            }
            
            while (DateTime.Now < endTime)
            {
                // Select a question that hasn't been used recently
                string question;
                do
                {
                    question = _questions[random.Next(_questions.Count)];
                } while (_usedQuestions.Contains(question) && _usedQuestions.Count < _questions.Count);
                
                _usedQuestions.Add(question);
                
                Console.Write($"> {question} ");
                ShowSpinner(10);
                Console.WriteLine();
                
                // Check if we have time for another question
                if ((endTime - DateTime.Now).TotalSeconds < 15)
                {
                    break;
                }
            }
            
            DisplayEndingMessage();
        }
    }
}