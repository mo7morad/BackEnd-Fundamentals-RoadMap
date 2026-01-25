/*
Translate Words Between Languages
Problem: Create a dictionary for translating words from one language to another.

Output:

Hello in Spanish: Hola

Goodbye in Spanish: Adiós
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> translations = new Dictionary<string, string>
        {
            { "Hello", "Hola" },
            { "Goodbye", "Adiós" }
        };
        
        Console.WriteLine($"Hello in Spanish: " + translations["Hello"]);
        Console.WriteLine($"Goodbye in Spanish: " + translations["Goodbye"]);
        // Output:
        // Hello in Spanish: Hola
        // Goodbye in Spanish: Adiós
    }
}

