/*
Find Words That Can Be Typed Using One Row of Keyboard


Problem: Return all words that can be typed using one row of a QWERTY keyboard.

Example:
Input: ["Hello", "Alaska", "Dad", "Peace"]
Output: ["Alaska", "Dad"]


Key Points:

Use a dictionary to map each character to its corresponding row.
*/

using System;
using System.Collections.Generic;

class Program
{
    public static IEnumerable<string> FindWords(string[] words)
    {
        // 1. The Dict mapping chars to 1, 2, or 3
        Dictionary<char, int> keyboardRows = new Dictionary<char, int>();

        string row1 = "qwertyuiop";
        string row2 = "asdfghjkl";
        string row3 = "zxcvbnm";

        foreach (char c in row1) keyboardRows[c] = 1;
        foreach (char c in row2) keyboardRows[c] = 2;
        foreach (char c in row3) keyboardRows[c] = 3;

        foreach (string word in words)
        {
            string lowerWord = word.ToLower();
            
            if (lowerWord.Length == 0) continue;

            // "First char value of dict will be the comparison"
            int wordRow = keyboardRows[lowerWord[0]];
            bool isValid = true;

            // Loop on each char in the word
            foreach (char c in lowerWord)
            {
                // "If it differs quit the word"
                if (keyboardRows[c] != wordRow)
                {
                    isValid = false;
                    break;
                }
            }

            // "If not (differs), add the word to the IEnumerable"
            if (isValid)
            {
                yield return word;
            }
        }
    }

    static void Main()
    {
        string[] input = { "Hello", "Alaska", "Dad", "Peace" };
        var result = FindWords(input);

        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}