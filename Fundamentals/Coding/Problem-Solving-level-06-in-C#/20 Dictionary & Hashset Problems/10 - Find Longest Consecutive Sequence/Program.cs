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
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2, 9, 10 };

        var result = GetLongestSequence(nums);

        Console.WriteLine($"Longest Streak: {result.Count()}");
        Console.WriteLine($"Sequence: [{string.Join(", ", result)}]");
    }

    static IEnumerable<int> GetLongestSequence(int[] nums)
    {
        if (nums == null || nums.Length == 0) return Enumerable.Empty<int>();

        HashSet<int> set = new HashSet<int>(nums);
        int longestStreak = 0;
        int bestEndNum = 0;

        foreach (int num in set)
        {
            if (set.Contains(num - 1)) continue;

            int currentNum = num;
            int currentStreak = 1;

            while (set.Contains(currentNum + 1))
            {
                currentNum++;
                currentStreak++;
            }

            if (currentStreak > longestStreak)
            {
                longestStreak = currentStreak;
                bestEndNum = currentNum;
            }
        }

        int startNum = bestEndNum - longestStreak + 1;
        return Enumerable.Range(startNum, longestStreak);
    }
}