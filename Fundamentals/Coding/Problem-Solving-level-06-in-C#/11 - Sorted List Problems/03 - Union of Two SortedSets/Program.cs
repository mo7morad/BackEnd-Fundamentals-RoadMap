/*

Union of Two SortedSets
Problem: Find the union of two SortedSet objects.

Example:
Input: set1 = [1, 2, 3], set2 = [3, 4, 5]
Output: [1, 2, 3, 4, 5]


Key Points:

Use UnionWith to compute the union.

*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> set1 = new SortedSet<int> { 1, 2, 3 };
        SortedSet<int> set2 = new SortedSet<int> { 3, 4, 5 };

        set1.UnionWith(set2);
        Console.WriteLine(string.Join(", ", set1)); // Output: 1, 2, 3, 4, 5
        Console.ReadKey();

    }
}