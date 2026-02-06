using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MindfulnessProgram
{
    public class ActivityLogger
    {
        private static string _logFile = "mindfulness_log.json";
        private static List<ActivityLog> _logs = new List<ActivityLog>();

        public class ActivityLog
        {
            public string ActivityName { get; set; }
            public int Duration { get; set; }
            public DateTime Date { get; set; }
            public string Notes { get; set; }
        }

        public static void LogActivity(string activityName, int duration, string notes = "")
        {
            var log = new ActivityLog
            {
                ActivityName = activityName,
                Duration = duration,
                Date = DateTime.Now,
                Notes = notes
            };

            _logs.Add(log);
            SaveLogs();
        }

        public static void LoadLogs()
        {
            try
            {
                if (File.Exists(_logFile))
                {
                    string json = File.ReadAllText(_logFile);
                    _logs = JsonSerializer.Deserialize<List<ActivityLog>>(json) ?? new List<ActivityLog>();
                }
            }
            catch
            {
                _logs = new List<ActivityLog>();
            }
        }

        private static void SaveLogs()
        {
            try
            {
                string json = JsonSerializer.Serialize(_logs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_logFile, json);
            }
            catch
            {
                // If we can't save, continue without logging
            }
        }

        public static void DisplayActivityHistory()
        {
            LoadLogs();
            
            Console.Clear();
            Console.WriteLine("=== Activity History ===\n");
            
            if (_logs.Count == 0)
            {
                Console.WriteLine("No activities logged yet.\n");
                return;
            }
            
            // Group by activity
            var groupedLogs = new Dictionary<string, List<ActivityLog>>();
            foreach (var log in _logs)
            {
                if (!groupedLogs.ContainsKey(log.ActivityName))
                {
                    groupedLogs[log.ActivityName] = new List<ActivityLog>();
                }
                groupedLogs[log.ActivityName].Add(log);
            }
            
            foreach (var group in groupedLogs)
            {
                Console.WriteLine($"{group.Key}:");
                Console.WriteLine($"  Total sessions: {group.Value.Count}");
                Console.WriteLine($"  Total time: {group.Value.Sum(l => l.Duration)} seconds");
                Console.WriteLine($"  Average session: {group.Value.Average(l => l.Duration):F1} seconds");
                Console.WriteLine();
            }
            
            Console.WriteLine($"\nLast 5 activities:");
            var recentLogs = _logs.OrderByDescending(l => l.Date).Take(5);
            foreach (var log in recentLogs)
            {
                Console.WriteLine($"  {log.Date:MM/dd HH:mm} - {log.ActivityName} ({log.Duration}s)");
                if (!string.IsNullOrEmpty(log.Notes))
                {
                    Console.WriteLine($"    Notes: {log.Notes}");
                }
            }
            
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}