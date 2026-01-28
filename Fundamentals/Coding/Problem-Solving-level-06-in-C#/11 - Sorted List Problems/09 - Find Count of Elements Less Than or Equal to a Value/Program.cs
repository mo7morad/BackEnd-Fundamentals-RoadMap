/*
Find Count of Elements Less Than or Equal to a Value
Problem: Count the number of elements in a SortedSet less than or equal to a given value.

Example:
Input: set = [1, 2, 3, 4, 5], value = 3
Output: 3


Key Points:

Use GetViewBetween and check the size of the subset.
*/

using System;
using System.Collections.Generic;

class Program
{
    static int CountLessThanOrEqual(SortedSet<int> set, int value)
    {
        return set.GetViewBetween(int.MinValue, value).Count;
    }

    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine(CountLessThanOrEqual(set, 3)); // Output: 3
        Console.ReadKey();
    }
}