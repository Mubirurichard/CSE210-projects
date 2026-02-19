using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                
                if (_amountCompleted == _target)
                {
                    Console.WriteLine($"Congratulations! You have completed the goal and earned {_points + _bonus} points (including {_bonus} bonus points)!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You have earned {_points} points! Progress: {_amountCompleted}/{_target}");
                }
            }
            else
            {
                Console.WriteLine("This goal has already been completed the required number of times!");
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {_shortName} - {_description} (Completed {_amountCompleted}/{_target} times)";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }

        // Additional method to get progress for display
        public string GetProgress()
        {
            return $"Completed {_amountCompleted}/{_target} times";
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
            : base(name, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }
    }
}