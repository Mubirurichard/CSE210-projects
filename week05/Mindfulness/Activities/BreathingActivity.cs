using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() 
            : base("Breathing", 
                  "This activity will help you relax by walking you through breathing in and out slowly. " +
                  "Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            Console.Clear();
            Console.WriteLine("Let's begin the breathing exercise...\n");
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            
            while (DateTime.Now < endTime)
            {
                // Breathe in
                if ((endTime - DateTime.Now).TotalSeconds >= 4)
                {
                    Console.Clear();
                    ShowBreathingAnimation("Breathe IN...", 4, true);
                }
                
                // Breathe out
                if ((endTime - DateTime.Now).TotalSeconds >= 6)
                {
                    Console.Clear();
                    ShowBreathingAnimation("Breathe OUT...", 6, false);
                }
                
                // If there's less time than a full cycle, just wait
                if ((endTime - DateTime.Now).TotalSeconds < 4)
                {
                    Thread.Sleep(1000);
                }
            }
            
            DisplayEndingMessage();
        }
    }
}