using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LAP_LENGTH_MILES = 0.031; // 50 meters in miles (50/1000 * 0.62)
        private const double LAP_LENGTH_KM = 0.05;     // 50 meters in km

        public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // Distance (miles) = swimming laps * 50 / 1000 * 0.62
            return _laps * LAP_LENGTH_MILES;
        }

        public override double GetSpeed()
        {
            // Speed (mph) = (distance / minutes) * 60
            return (GetDistance() / GetLengthInMinutes()) * 60;
        }

        public override double GetPace()
        {
            // Pace (min per mile) = minutes / distance
            return GetLengthInMinutes() / GetDistance();
        }
    }
}