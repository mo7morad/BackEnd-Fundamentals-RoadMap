/*
Find Duplicate Elements
Problem: Identify duplicate elements in an array.

Example:
Input: [1, 2, 3, 4, 2, 5, 6, 1]
Output: [1, 2]


Key Points:

Use a dictionary to count occurrences and collect duplicates.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 2, 3, 4, 2, 5, 6, 1 };
        List<int> duplicates = new List<int>();
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in nums)
        {
            if (!seen.Add(num))
            {
                duplicates.Add(num);
            }
        }

        Console.WriteLine($"Duplicates: [{string.Join(", ", duplicates)}]");
    }
}