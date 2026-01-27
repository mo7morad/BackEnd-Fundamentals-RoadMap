/*

Find Numbers Disappeared in an Array
Problem: Find all numbers missing from the range 1 to n in an array.

Example:
Input: [4, 3, 2, 7, 8, 2, 3, 1]
Output: [5, 6]


Key Points:

Use a HashSet to track existing numbers.

*/

using System;
using System.Collections.Generic;

class Program
{
    static IEnumerable<int> FindDisappearedNumbers(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        for (int i = 1; i <= nums.Length; i++)
        {
            if (!set.Contains(i))
            {
                yield return i;
            }
        }
    }

    static void Main()
    {
        int[] input = { 4, 3, 2, 7, 8, 2, 3, 1 };
        
        var result = FindDisappearedNumbers(input);

        Console.WriteLine("[" + string.Join(", ", result) + "]");
        // Output: [5, 6]
    }
}