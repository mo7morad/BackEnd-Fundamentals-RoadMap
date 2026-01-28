/*
Remove All Elements Within a Range
Problem: Remove all elements within a specified range from a SortedSet.

Example:
Input: set = [1, 2, 3, 4, 5], range = [2, 4]
Output: [1, 5]


Key Points:

Use GetViewBetween and Clear to remove the range.

*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        var range = set.GetViewBetween(2, 4);
        range.Clear();

        Console.WriteLine(string.Join(", ", set)); // Output: 1, 5
        Console.ReadKey();
    }
}
