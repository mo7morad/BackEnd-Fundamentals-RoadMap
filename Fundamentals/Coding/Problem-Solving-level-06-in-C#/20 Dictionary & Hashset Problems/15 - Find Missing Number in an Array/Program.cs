/*
Find Missing Number in an Array
Problem: Find the missing number in an array of size n containing numbers from 0 to n.

Example:
Input: [3, 0, 1]
Output: 2


Key Points:

Use a dictionary to track presence of numbers.
*/

using System;
using System.Collections.Generic;

class Program
{
    static int FindMissingNumber(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        for (int i = 0; i <= nums.Length; i++)
        {
            if (!set.Contains(i))
            {
                return i;
            }
        }
        return -1;
    }

    static int FindMissingNumberMath(int[] nums)
    {
        int n = nums.Length;

        // Math Formula for sum of first n natural numbers
        int expectedSum = n * (n + 1) / 2;
        
        int actualSum = 0;
        foreach (int num in nums)
        {
            actualSum += num;
        }
        
        return expectedSum - actualSum;
    }

    static void Main()
    {
        int[] input = { 3, 0, 1 };
        Console.WriteLine("Missing Number: " + FindMissingNumber(input));
    }
}