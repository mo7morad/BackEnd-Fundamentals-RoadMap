/*
Find Elements Not in the Second Array
Problem: Find all elements in the first array that are not in the second array.

Example:
Input: nums1 = [1, 2, 3, 4], nums2 = [3, 4, 5, 6]
Output: [1, 2]


Key Points:

Use a HashSet to store the second array's elements for quick lookups.
*/

using System;
using System.Collections.Generic;

class Program
{
    static IEnumerable<int> FindDifference(int[] nums1, int[] nums2)
    {
        HashSet<int> set2 = new HashSet<int>(nums2);

        foreach (int num in nums1)
        {
            if (!set2.Contains(num))
            {
                yield return num;
            }
        }
    }

    static void Main()
    {
        int[] nums1 = { 1, 2, 3, 4 };
        int[] nums2 = { 3, 4, 5, 6 };

        var result = FindDifference(nums1, nums2);

        Console.WriteLine("[" + string.Join(", ", result) + "]");
        // Output: [1, 2]
    }
}