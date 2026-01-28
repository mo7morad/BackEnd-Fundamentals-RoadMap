/*
Check If Set Contains Multiple Ranges
Problem: Check if a SortedSet contains elements from multiple specified ranges.

Example:
Input: set = [1, 2, 3, 4, 5], ranges = [(1, 2), (4, 5)]
Output: True


Key Points:

Use GetViewBetween for each range and check if all elements exist.
*/

using System;
using System.Collections.Generic;

class Program
{
    static bool ContainsAllRanges(SortedSet<int> set, List<(int, int)> ranges)
    {
        if (low > high) return false;
        foreach (var (low, high) in ranges)
        {
            var range = set.GetViewBetween(low, high);
            if (range.Count != (high - low + 1))
                return false;
        }
        return true;
    }

    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        var ranges = new List<(int, int)> { (1, 2), (4, 5) };
        Console.WriteLine(ContainsAllRanges(set, ranges)); // Output: True
        Console.ReadKey();
    }
}
