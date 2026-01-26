using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Person Class Demo ===");
        
        // Test different constructors
        Person person1 = new Person();
        Person person2 = new Person("John", "Doe");
        Person person3 = new Person("Dr.", "Jane", "Smith");
        
        // Set values for person1 using setters
        person1.SetFirstName("Bob");
        person1.SetLastName("Johnson");
        
        // Test signatures
        Console.WriteLine("\nPerson 1:");
        Console.WriteLine("Informal: " + person1.GetInformalSignature());
        Console.WriteLine("Formal: " + person1.GetFormalSignature());
        
        Console.WriteLine("\nPerson 2:");
        Console.WriteLine("Informal: " + person2.GetInformalSignature());
        Console.WriteLine("Formal: " + person2.GetFormalSignature());
        
        Console.WriteLine("\nPerson 3:");
        Console.WriteLine("Informal: " + person3.GetInformalSignature());
        Console.WriteLine("Formal: " + person3.GetFormalSignature());
        
        // Test getters
        Console.WriteLine("\nPerson 3 Details:");
        Console.WriteLine("Title: " + person3.GetTitle());
        Console.WriteLine("First Name: " + person3.GetFirstName());
        Console.WriteLine("Last Name: " + person3.GetLastName());

                Console.WriteLine("=== Fraction Class Demo ===");
        
        // Test all three constructors
        Fraction f1 = new Fraction();      // 1/1
        Fraction f2 = new Fraction(5);     // 5/1
        Fraction f3 = new Fraction(3, 4);  // 3/4
        Fraction f4 = new Fraction(1, 3);  // 1/3
        
        // Display fractions and their decimal values
        Console.WriteLine("\nTesting Constructors:");
        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);
        DisplayFraction(f4);
        
        // Test getters and setters
        Console.WriteLine("\nTesting Getters and Setters:");
        
        // Original values
        Console.WriteLine($"f3 Original: Top = {f3.GetTop()}, Bottom = {f3.GetBottom()}");
        
        // Change values using setters
        f3.SetTop(7);
        f3.SetBottom(8);
        Console.WriteLine($"f3 Modified: {f3.GetFractionString()}");
        Console.WriteLine($"Decimal value: {f3.GetDecimalValue()}");
        
        // Test edge cases
        Console.WriteLine("\nTesting Edge Cases:");
        Fraction f5 = new Fraction();
        f5.SetBottom(0); // Should handle division by zero
        Console.WriteLine($"Attempted to set denominator to 0: {f5.GetFractionString()}");
    }
    
    static void DisplayFraction(Fraction f)
    {
        Console.WriteLine($"Fraction: {f.GetFractionString()}");
        Console.WriteLine($"Decimal: {f.GetDecimalValue()}");
    }
}