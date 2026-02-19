using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            // Speed = (distance / minutes) * 60
            return (_distance / GetLengthInMinutes()) * 60;
        }

        public override double GetPace()
        {
            // Pace = minutes / distance
            return GetLengthInMinutes() / _distance;
        }
    }
}