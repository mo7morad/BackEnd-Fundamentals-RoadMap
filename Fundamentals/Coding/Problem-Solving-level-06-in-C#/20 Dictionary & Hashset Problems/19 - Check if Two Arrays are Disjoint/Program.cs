/*Check if Two Arrays are Disjoint
Problem: Determine if two arrays have no common elements.

Example:
Input: nums1 = [1, 2, 3], nums2 = [4, 5, 6]
Output: True


Key Points:

Use a HashSet to check for common elements
*/

using System;
using System.Collections.Generic;

class Program
{
    static bool AreDisjoint(int[] nums1, int[] nums2)
    {
        HashSet<int> set = new HashSet<int>(nums1);

        foreach (int num in nums2)
        {
            if (set.Contains(num))
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        int[] nums1 = { 1, 2, 3 };
        int[] nums2 = { 4, 5, 6 };
        
        // Output: True
        Console.WriteLine("Are Disjoint: " + AreDisjoint(nums1, nums2)); 
        
        int[] nums3 = { 1, 2, 3 };
        int[] nums4 = { 3, 4, 5 };
        
        // Output: False
        Console.WriteLine("Are Disjoint: " + AreDisjoint(nums3, nums4));
    }
}