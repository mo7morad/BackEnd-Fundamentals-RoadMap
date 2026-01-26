/*
Find All Unique Elements
Problem: Return all unique elements from an array.

Example:
Input: [1, 2, 2, 3, 4, 5, 3]
Output: [1, 4, 5]


Key Points:

Use a dictionary to track occurrences and filter unique elements.
*/

using System;
using System.Collections.Generic;

class Program
{
    static List<int> FindUniqueElements(int[] nums)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        List<int> unique = new List<int>();

        foreach (int num in nums)
        {
            counts[num] = counts.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var item in counts)
        {
            if (item.Value == 1)
            {
                unique.Add(item.Key);
            }
        }

        return unique;
    }

    static void Main()
    {
        int[] nums = { 1, 2, 2, 3, 4, 5, 3 };
        List<int> result = FindUniqueElements(nums);
        Console.WriteLine("Unique Elements: [" + string.Join(", ", result) + "]");
    }
}