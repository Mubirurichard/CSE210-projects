using System;
using System.Threading;

namespace MindfulnessProgram
{
    class Program
    {
        /*
        EXCEEDING REQUIREMENTS:
        
        1. ADDED A FOURTH ACTIVITY: Gratitude Activity
           - A specialized activity focused on cultivating gratitude
           - Includes structured reflection across 8 different categories
           - Based on psychological research showing gratitude increases happiness
        
        2. ACTIVITY STATISTICS TRACKING
           - Tracks total activities completed across all sessions
           - Tracks total time spent on mindfulness activities
           - Displays average session length
           - Statistics persist through the program run
        
        3. ENHANCED ANIMATIONS
           - Created a breathing visualization that grows/shrinks
           - Added more spinner characters for variety
           - Countdown timers with visual feedback
        
        4. LOGGING SYSTEM
           - Saves activity history to a JSON file
           - Tracks activity name, duration, date, and optional notes
           - Displays activity history and statistics
           - Prevents duplicate questions in reflection activity until all are used
        
        5. IMPROVED USER INTERFACE
           - Better menu system with statistics option
           - Color-coded activity selection
           - Progress indicators during activities
           - Time remaining displays
        
        6. ADDITIONAL PROMPTS AND QUESTIONS
           - Expanded lists for all activities
           - More varied and thought-provoking prompts
           - Categories for gratitude practice
        */
        
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            
            // Load previous logs
            ActivityLogger.LoadLogs();
            
            bool exit = false;
            
            while (!exit)
            {
                Console.Clear();
                DisplayMenu();
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        RunBreathingActivity();
                        break;
                    case "2":
                        RunReflectionActivity();
                        break;
                    case "3":
                        RunListingActivity();
                        break;
                    case "4":
                        RunGratitudeActivity();
                        break;
                    case "5":
                        ActivityLogger.DisplayActivityHistory();
                        break;
                    case "6":
                        Activity.DisplayStatistics();
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("\nThank you for practicing mindfulness!");
                        Console.WriteLine("Have a peaceful day! 🌟");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
        
        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     MINDFULNESS PROGRAM v2.0       ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
            
            Console.WriteLine("\nSelect an activity:");
            Console.WriteLine("────────────────────");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (NEW!)");
            Console.ResetColor();
            
            Console.WriteLine("\nAdditional Options:");
            Console.WriteLine("────────────────────");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("5. View Activity History");
            Console.WriteLine("6. View Session Statistics");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("7. Exit");
            Console.ResetColor();
            
            Console.Write("\nEnter your choice (1-7): ");
        }
        
        static void RunBreathingActivity()
        {
            var activity = new BreathingActivity();
            activity.Run();
            ActivityLogger.LogActivity("Breathing", activity.Duration, "Focused breathing exercise");
        }
        
        static void RunReflectionActivity()
        {
            var activity = new ReflectionActivity();
            activity.Run();
            ActivityLogger.LogActivity("Reflection", activity.Duration, "Self-reflection exercise");
        }
        
        static void RunListingActivity()
        {
            var activity = new ListingActivity();
            activity.Run();
            ActivityLogger.LogActivity("Listing", activity.Duration, "Positive listing exercise");
        }
        
        static void RunGratitudeActivity()
        {
            var activity = new GratitudeActivity();
            activity.Run();
            ActivityLogger.LogActivity("Gratitude", activity.Duration, "Gratitude practice exercise");
        }
    }
}