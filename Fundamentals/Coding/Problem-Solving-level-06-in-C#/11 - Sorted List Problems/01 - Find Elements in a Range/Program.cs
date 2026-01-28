/*
Find Elements in a Range
Problem: Find all elements in a SortedSet within a given range [low, high].

Example:
Input: set = [1, 2, 3, 4, 5], low = 2, high = 4
Output: [2, 3, 4]


Key Points:

Use GetViewBetween to get a subset within the range.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
        var range = sortedSet.GetViewBetween(2, 4);

        Console.WriteLine(string.Join(", ", range)); // Output: 2, 3, 4
        Console.ReadKey();

    }
}
