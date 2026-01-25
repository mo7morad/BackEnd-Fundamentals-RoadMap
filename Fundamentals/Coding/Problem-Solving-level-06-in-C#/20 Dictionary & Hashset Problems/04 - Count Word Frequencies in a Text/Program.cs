/*
Count Word Frequencies in a Text
Problem: Count the frequency of each word in a given text.

Input: "hello world hello universe"

Output:

hello: 2

world: 1

universe: 1
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();
        string text = "hello world hello universe";

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            if (wordFrequencies.ContainsKey(word))
            {
                wordFrequencies[word]++;
            }
            else
            {
                wordFrequencies[word] = 1;
            }
        }

        foreach (var pair in wordFrequencies)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        // Output:
        // hello: 2
        // world: 1
        // universe: 1
    }
}

