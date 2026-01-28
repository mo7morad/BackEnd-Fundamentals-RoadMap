/*
Find All Elements Not in a Range
Problem: Find all elements in a SortedSet that are outside a given range [low, high].

Example:
Input: set = [1, 2, 3, 4, 5], range = [2, 4]
Output: [1, 5]


Key Points:

Use GetViewBetween and remove the range from the set.
*/

using System;
using System.Collections.Generic;


class Program
{
    static IEnumerable<int> ElementsNotInRange(SortedSet<int> set, int low, int high)
    {
        var range = set.GetViewBetween(low, high);
        SortedSet<int> result = new SortedSet<int>(set);
        result.ExceptWith(range);
        return result;
    }

    static IEnumerable<int> ElementsNotInRange(SortedSet<int> set, int low, int high)
    {
        return set.Where(x => x < low || x > high);
    }

    static void Main()
    {
        SortedSet<int> set = new SortedSet<int> { 1, 2, 3, 4, 5 };
        var result = ElementsNotInRange(set, 2, 4);
        Console.WriteLine(string.Join(", ", result)); // Output: 1, 5
        Console.ReadKey();

    }
}
