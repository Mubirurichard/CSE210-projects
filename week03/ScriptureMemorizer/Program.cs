using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture (John 3:16 example)
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        
        Scripture scripture = new Scripture(reference, scriptureText);

        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.\n");

        // Main loop
        while (true)
        {
            // Clear console and display scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Press any key to exit.");
                Console.ReadKey();
                break;
            }
            
            // Prompt user
            Console.Write("\nPress Enter to continue or type 'quit': ");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            scripture.HideRandomWords(3);
        }
        
        Console.WriteLine("\nGoodbye!");
    }
}