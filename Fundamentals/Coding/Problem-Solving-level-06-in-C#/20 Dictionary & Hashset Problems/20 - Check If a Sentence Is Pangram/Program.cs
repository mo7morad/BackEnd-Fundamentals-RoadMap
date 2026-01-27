/*
Check If a Sentence Is Pangram
Problem: Check if a sentence contains every letter of the English alphabet at least once.

Example:


Input: "The quick brown fox jumps over the lazy dog"
Output: True

Key Points:

Use a HashSet to store unique letters.

*/

using System;
using System.Collections.Generic;

class Program
{
    static bool CheckPangram(string sentence)
    {
        HashSet<char> letters = new HashSet<char>();

        foreach (char c in sentence.ToLower())
        {
            if (char.IsLetter(c))
            {
                letters.Add(c);
            }
        }

        return letters.Count == 26;
    }

    static void Main()
    {
        string input = "The quick brown fox jumps over the lazy dog";
        Console.WriteLine("Is Pangram: " + CheckPangram(input)); // True

        string input2 = "Hello World";
        Console.WriteLine("Is Pangram: " + CheckPangram(input2)); // False
    }
}