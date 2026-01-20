using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter the grade:");
        string GradeInput = Console.ReadLine();
        int percent = int.Parse(GradeInput);
        string letter = "";
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = percent % 10;
        string sign = "";
        
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        
        if (letter == "A")
        {
            sign = "";
        }
        else if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time. consider studying more!");
        }

    }
}