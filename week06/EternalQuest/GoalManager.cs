using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
        }

        public void Start()
        {
            int choice = 0;
            do
            {
                DisplayPlayerInfo();
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Record Event");
                Console.WriteLine("  4. Save Goals");
                Console.WriteLine("  5. Load Goals");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            CreateGoal();
                            break;
                        case 2:
                            ListGoalDetails();
                            break;
                        case 3:
                            RecordEvent();
                            break;
                        case 4:
                            SaveGoals();
                            break;
                        case 5:
                            LoadGoals();
                            break;
                        case 6:
                            Console.WriteLine("Thank you for using the Eternal Quest program! Keep striving for your goals!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (choice != 6);
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\n=== Eternal Quest ===");
            Console.WriteLine($"Current Score: {_score} points");
            Console.WriteLine($"Current Level: {_level} (Next level: {_level * 1000} points)");
            Console.WriteLine("=====================");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            Console.WriteLine("Your Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of goals are:");
            Console.WriteLine("  1. Simple Goal (one-time completion)");
            Console.WriteLine("  2. Eternal Goal (never ends, repeatable)");
            Console.WriteLine("  3. Checklist Goal (complete multiple times for bonus)");
            Console.Write("Which type of goal would you like to create? ");
            
            if (int.TryParse(Console.ReadLine(), out int type))
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                
                Console.Write("What is the amount of points associated with this goal? ");
                if (int.TryParse(Console.ReadLine(), out int points))
                {
                    Goal goal = null;
                    
                    switch (type)
                    {
                        case 1: // Simple Goal
                            goal = new SimpleGoal(name, description, points);
                            break;
                            
                        case 2: // Eternal Goal
                            goal = new EternalGoal(name, description, points);
                            break;
                            
                        case 3: // Checklist Goal
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            if (int.TryParse(Console.ReadLine(), out int target))
                            {
                                Console.Write("What is the bonus for accomplishing it that many times? ");
                                if (int.TryParse(Console.ReadLine(), out int bonus))
                                {
                                    goal = new ChecklistGoal(name, description, points, target, bonus);
                                }
                            }
                            break;
                    }
                    
                    if (goal != null)
                    {
                        _goals.Add(goal);
                        Console.WriteLine($"Goal '{name}' created successfully!");
                    }
                }
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Create a goal first!");
                return;
            }

            Console.WriteLine("Which goal did you accomplish?");
            ListGoalNames();
            Console.Write("Select a goal: ");
            
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
            {
                Goal selectedGoal = _goals[index - 1];
                
                // Store old completion status for checklist goals
                bool wasComplete = selectedGoal.IsComplete();
                
                selectedGoal.RecordEvent();
                
                // Add points (including bonus if applicable)
                if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    // For checklist goals, points are added in the RecordEvent method
                    // We need to calculate points earned
                    if (!wasComplete && checklistGoal.IsComplete())
                    {
                        // Just completed the goal, got points + bonus
                        _score += selectedGoal.GetPoints() + ((ChecklistGoal)selectedGoal).GetBonus();
                    }
                    else if (!wasComplete)
                    {
                        // Progress made but not complete
                        _score += selectedGoal.GetPoints();
                    }
                }
                else
                {
                    // For other goals, add points if event was recorded
                    _score += selectedGoal.GetPoints();
                }
                
                // Check for level up
                CheckLevelUp();
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        private void CheckLevelUp()
        {
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine($"\n*** LEVEL UP! You are now level {_level}! ***\n");
            }
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save (default: goals.txt): ");
            string filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                filename = "goals.txt";
            }

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    // Save score and level first
                    outputFile.WriteLine($"{_score}|{_level}");
                    
                    // Save each goal
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine($"Goals saved successfully to {filename}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load (default: goals.txt): ");
            string filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                filename = "goals.txt";
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} does not exist.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                _goals.Clear();
                
                // First line contains score and level
                if (lines.Length > 0)
                {
                    string[] scoreParts = lines[0].Split('|');
                    if (scoreParts.Length >= 2)
                    {
                        _score = int.Parse(scoreParts[0]);
                        _level = int.Parse(scoreParts[1]);
                    }
                }
                
                // Load goals from remaining lines
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    
                    string[] parts = line.Split(':');
                    if (parts.Length < 2) continue;
                    
                    string goalType = parts[0];
                    string[] details = parts[1].Split(',');
                    
                    Goal goal = null;
                    
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            if (details.Length >= 4)
                            {
                                bool isComplete = bool.Parse(details[3]);
                                goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]), isComplete);
                            }
                            break;
                            
                        case "EternalGoal":
                            if (details.Length >= 3)
                            {
                                goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                            }
                            break;
                            
                        case "ChecklistGoal":
                            if (details.Length >= 6)
                            {
                                goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), 
                                    int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5]));
                            }
                            break;
                    }
                    
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }
                
                Console.WriteLine($"Goals loaded successfully from {filename}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
    }
}