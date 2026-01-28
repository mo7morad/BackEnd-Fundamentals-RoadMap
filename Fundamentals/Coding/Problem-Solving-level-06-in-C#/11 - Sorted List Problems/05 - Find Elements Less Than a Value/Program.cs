/*
Find Elements Less Than a Value
Problem: Find all elements in a SortedSet less than a given value.

Example:
Input: set = [1, 2, 3, 4, 5], value = 4
Output: [1, 2, 3]


Key Points:

Use GetViewBetween to get a subset.
*/

using System;
using System.Collections.Generic;

class Program
{
    static IEnumerable<int> ElementsLessThan(SortedSet<int> set, int value)
    {
        return set.GetViewBetween(int.MinValue, value - 1);
    }

    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        int value = 4;
        Console.WriteLine(string.Join(", ", ElementsLessThan(set, value))); // Output: 1, 2, 3
      }
  }
