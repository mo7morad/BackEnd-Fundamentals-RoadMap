// problem

/*
 * 
First Non-Repeating Character in a Stream
Problem: Given a stream of characters, find the first non-repeating character after each insertion.

Example:
Input: "aabc"
Output: a, -, b, c


Key Points:

Use a queue to track the order of characters.
Use a dictionary to count occurrences.

*/

using System;
using System.Collections.Generic;

class Program
{
    static void FindFirstNonRepeating(string stream)
    {
        HashSet<char> seenCharacters = new HashSet<char>();
        List<string> outputBuffer = new List<string>();

        foreach (char ch in stream)
        {
            // 1. Ignore spaces
            if (char.IsWhiteSpace(ch))
                continue;

            if (seenCharacters.Add(ch))
            {
                outputBuffer.Add(ch.ToString());
            }
            else
            {
                outputBuffer.Add("-");
            }
        }

        Console.WriteLine(string.Join(", ", outputBuffer));
    }

    static void Main()
    {
        string input = "aabc";
        Console.WriteLine($"Input: {input}");
        Console.Write("Output: ");
        FindFirstNonRepeating(input);  // Output: a, -, b, c

        Console.WriteLine();

        string input2 = "The quick brown fox jumps over the lazy dog";
        Console.WriteLine($"Input: {input2}");
        Console.Write("Output: ");
        FindFirstNonRepeating(input2);
    }
}