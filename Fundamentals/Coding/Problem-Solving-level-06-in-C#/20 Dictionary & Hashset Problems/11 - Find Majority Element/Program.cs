/*
Find Majority Element
Problem: Find the majority element in an array (element appearing more than n/2 times).

Example:
Input: [3, 2, 3]
Output: 3

Key Points:

Use a dictionary to count frequencies.
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 3, 2, 3 };
        int majorityElement = FindMajorityElement(nums);
        Console.WriteLine("Majority Element: " + majorityElement);
    }

    static int FindMajorityElement(int[] nums)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        int majorityCount = nums.Length / 2;

        foreach (int num in nums)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]++;
            }
            else
            {
                frequencyMap[num] = 1;
            }

            if (frequencyMap[num] > majorityCount)
            {
                return num;
            }
        }

        throw new InvalidOperationException("No majority element found");
    }
}

