using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("Embark on your journey to achieve your goals and earn rewards!");
            
            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }
}