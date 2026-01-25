/*
Find the Frequency of Each Character
Problem: Count the frequency of each character in a string.

Example:
Input: "hello"
Output: { 'h': 1, 'e': 1, 'l': 2, 'o': 1 }


Key Points:

Use a dictionary to map characters to their frequency.
*/


using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, int> CharacterFrequency(string input)
    {
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        
        foreach (char c in input)
        {
            charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
        }
        return frequency;
    }

    static void Main()
    {
        string input = "hello";
        var result = CharacterFrequency(input);
        foreach (var kvp in result)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.ReadKey();

    }
}

