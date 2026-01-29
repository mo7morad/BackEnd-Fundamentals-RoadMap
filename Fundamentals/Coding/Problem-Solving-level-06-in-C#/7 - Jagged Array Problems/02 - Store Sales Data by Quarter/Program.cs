/*
Store Sales Data by Quarter
Problem: Store sales data for a company across different regions for various quarters.


Example:
Input:

Region 1: [10000, 12000, 11000]
Region 2: [15000, 16000]
Region 3: [9000, 9500, 9800, 10200]


Output: Display quarterly sales for each region.
*/

using System;

class Program
{
    static void Main()
    {
        int[][] salesData = new int[][]
        {
            new int[] { 10000, 12000, 11000 },
            new int[] { 15000, 16000 },
            new int[] { 9000, 9500, 9800, 10200 }
        };

        for (int i = 0; i < salesData.Length; i++)
        {
            Console.Write($"Region {i + 1}: ");
            Console.WriteLine(string.Join(", ", salesData[i]));
        }
    }
}