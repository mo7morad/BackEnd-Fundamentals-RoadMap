/*
Store and Retrieve Student Grades
Problem: Store the grades of students using their names as keys, and retrieve Bob's Info using student name.

Output: Student: Bob, Grade: 90
*/


using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, int> CharacterFrequency(string input)
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

