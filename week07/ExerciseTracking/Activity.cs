using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _lengthInMinutes;

        public Activity(DateTime date, int lengthInMinutes)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public int GetLengthInMinutes()
        {
            return _lengthInMinutes;
        }

        // Abstract methods to be overridden by derived classes
        public abstract double GetDistance(); // in miles or km
        public abstract double GetSpeed();    // in mph or kph
        public abstract double GetPace();     // in minutes per mile or per km

        // Virtual method that uses the abstract methods - doesn't need to be overridden
        public virtual string GetSummary()
        {
            return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_lengthInMinutes} min)- " +
                   $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}