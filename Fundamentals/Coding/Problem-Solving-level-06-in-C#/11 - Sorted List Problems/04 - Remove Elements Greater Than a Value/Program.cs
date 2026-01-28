/*
Remove Elements Greater Than a Value
Problem: Remove all elements from a SortedSet that are greater than a specified value.

Example:
Input: set = [1, 2, 3, 4, 5], value = 3
Output: [1, 2, 3]


Key Points:

Use GetViewBetween to create a range and then replace the set.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
        var range = sortedSet.GetViewBetween(int.MinValue, 3);

        sortedSet = new SortedSet<int>(range);
        Console.WriteLine(string.Join(", ", sortedSet)); // Output: 1, 2, 3
        Console.ReadKey();
    }
}