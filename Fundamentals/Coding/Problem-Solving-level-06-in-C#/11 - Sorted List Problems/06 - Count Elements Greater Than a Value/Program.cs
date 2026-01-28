/*
Count Elements Greater Than a Value
Problem: Count the number of elements greater than a given value in a SortedSet.

Example:
Input: set = [1, 2, 3, 4, 5], value = 3
Output: 2


Key Points:

Use GetViewBetween to create a subset.
*/

using System;
using System.Collections.Generic;

class Program
{
    static int CountGreaterThan(SortedSet<int> set, int value)
    {
        return set.GetViewBetween(value + 1, int.MaxValue).Count;
    }

    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        int value = 3;
        Console.WriteLine(CountGreaterThan(set, value)); // Output: 2
        Console.ReadKey();
    }
}
