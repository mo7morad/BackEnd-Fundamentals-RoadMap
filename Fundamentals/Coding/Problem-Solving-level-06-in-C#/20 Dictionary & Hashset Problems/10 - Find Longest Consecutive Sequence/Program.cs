/*
Find Longest Consecutive Sequence
Problem: Find the length of the longest consecutive sequence in an array.

Example:
Input: [100, 4, 200, 1, 3, 2]
Output: 4 (sequence: [1, 2, 3, 4])


Key Points:

Use a dictionary (or hash set) to check the existence of elements efficiently.
*/


using System;
using System.Collections.Generic;

class Program
{
    static int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        int longestStreak = 0;


        foreach (int num in set)
        {
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;


                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }


                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }


        return longestStreak;
    }

    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2};
        Console.WriteLine(LongestConsecutive(nums)); // Output: 4
    }

}
