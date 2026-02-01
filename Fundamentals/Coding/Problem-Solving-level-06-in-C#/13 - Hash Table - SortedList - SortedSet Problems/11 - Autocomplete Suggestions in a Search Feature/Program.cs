using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<string> dictionary = new SortedSet<string>(StringComparer.Ordinal)
        {
            "car",
            "camera",
            "cat",
            "cart",
            "carbon",
            "banana",
            "apple"
        };

        Console.Write("Enter prefix to search (e.g., 'ca'): ");
        
        string prefix = Console.ReadLine()?.ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(prefix))
        {
            Console.WriteLine("Input cannot be empty.");
            return;
        }

        try 
        {
            var suggestions = dictionary.GetViewBetween(prefix, prefix + "~");

            Console.WriteLine($"\nSuggestions for '{prefix}':");
            foreach (string word in suggestions)
            {
                Console.WriteLine($"- {word}");
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("No suggestions found.");
        }
    }
}