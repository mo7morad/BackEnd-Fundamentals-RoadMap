/*
Dynamic Seating Arrangement in a Classroom
Problem: Each row in a classroom has a different number of seats. 
Store the seating arrangement and access each seat dynamically.
*/

using System;
class Program
{
    static void Main()
    {
        int[][] classroomSeats = new int[3][];
        classroomSeats[0] = new int[] { 1, 2, 3 }; // Row 1
        classroomSeats[1] = new int[] { 4, 5 };    // Row 2
        classroomSeats[2] = new int[] { 6, 7, 8, 9 }; // Row 3


        Console.WriteLine("Classroom Seating:");
        for (int i = 0; i < classroomSeats.Length; i++)
        {
            Console.Write($"Row {i + 1}: ");
            Console.WriteLine(string.Join(", ", classroomSeats[i]));
        }
        // Output:
        // Row 1: 1 2 3
        // Row 2: 4 5
        // Row 3: 6 7 8 9
    }
}
