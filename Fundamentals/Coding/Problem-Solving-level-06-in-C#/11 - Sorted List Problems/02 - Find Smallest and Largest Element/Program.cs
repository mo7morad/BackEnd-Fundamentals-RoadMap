/*
Find Smallest and Largest Element
Problem: Find the smallest and largest element in a SortedSet.

Example:
Input: [4, 2, 5, 1, 3]
Output: Smallest: 1, Largest: 5


Key Points:

Use Min and Max properties.

*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> sortedSet = new SortedSet<int> { 4, 2, 5, 1, 3 };
        Console.WriteLine($"Smallest: {sortedSet.Min}, Largest: {sortedSet.Max}");
        // Output: Smallest: 1, Largest: 5
        Console.ReadKey();
    }
}