using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise Tracking Program");
            Console.WriteLine("=========================\n");

            // Create activities
            List<Activity> activities = new List<Activity>();

            // Running activity
            DateTime runningDate = new DateTime(2022, 11, 3);
            Running running = new Running(runningDate, 30, 3.0); // 3 miles in 30 minutes
            activities.Add(running);

            // Cycling activity
            DateTime cyclingDate = new DateTime(2022, 11, 3);
            Cycling cycling = new Cycling(cyclingDate, 45, 15.0); // 15 mph for 45 minutes
            activities.Add(cycling);

            // Swimming activity
            DateTime swimmingDate = new DateTime(2022, 11, 3);
            Swimming swimming = new Swimming(swimmingDate, 20, 20); // 20 laps in 20 minutes
            activities.Add(swimming);

            // Additional activities to demonstrate variety
            DateTime anotherDate = new DateTime(2022, 11, 4);
            Running running2 = new Running(anotherDate, 60, 6.2); // 6.2 miles (10k) in 60 minutes
            activities.Add(running2);

            Cycling cycling2 = new Cycling(anotherDate, 90, 12.5); // 12.5 mph for 90 minutes
            activities.Add(cycling2);

            Swimming swimming2 = new Swimming(anotherDate, 45, 40); // 40 laps in 45 minutes
            activities.Add(swimming2);

            // Display summaries for all activities
            Console.WriteLine("Activity Summaries:");
            Console.WriteLine("-------------------\n");

            int count = 1;
            foreach (Activity activity in activities)
            {
                Console.WriteLine($"{count}. {activity.GetSummary()}");
                count++;
            }

            // Additional verification to show calculations are correct
            Console.WriteLine("\nVerification of Calculations:");
            Console.WriteLine("-----------------------------\n");

            // Verify Running calculations
            Console.WriteLine("Running Verification (3 miles in 30 minutes):");
            Console.WriteLine($"  Distance: {running.GetDistance():F1} miles (expected: 3.0)");
            Console.WriteLine($"  Speed: {running.GetSpeed():F1} mph (expected: 6.0)");
            Console.WriteLine($"  Pace: {running.GetPace():F2} min/mile (expected: 10.0)");

            // Verify Cycling calculations
            Console.WriteLine("\nCycling Verification (15 mph for 45 minutes):");
            Console.WriteLine($"  Distance: {cycling.GetDistance():F1} miles (expected: 11.25)");
            Console.WriteLine($"  Speed: {cycling.GetSpeed():F1} mph (expected: 15.0)");
            Console.WriteLine($"  Pace: {cycling.GetPace():F2} min/mile (expected: 4.0)");

            // Verify Swimming calculations
            Console.WriteLine("\nSwimming Verification (20 laps in 20 minutes, 50m lap):");
            Console.WriteLine($"  Distance: {swimming.GetDistance():F3} miles (expected: 0.620)");
            Console.WriteLine($"  Speed: {swimming.GetSpeed():F1} mph (expected: 1.9)");
            Console.WriteLine($"  Pace: {swimming.GetPace():F2} min/mile (expected: 32.26)");

            Console.WriteLine("\nProgram completed successfully.");
        }
    }
}