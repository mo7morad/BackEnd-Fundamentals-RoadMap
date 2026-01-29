/*
Store Marks of Students in Multiple Subjects
Problem: Use a jagged array to store marks of students across different subjects.

Example:
Input:

Student 1: [90, 85, 88]
Student 2: [76, 80]
Student 3: [92, 93, 89, 85]
Output: Display marks for each student.
*/

using System;

class Program
{
    static void Main()
    {
        int[][] studentMarks = new int[3][];

        studentMarks[0] = new int[] { 90, 85, 88 };         
        studentMarks[1] = new int[] { 76, 80 };             
        studentMarks[2] = new int[] { 92, 93, 89, 85 };     

        for (int i = 0; i < studentMarks.Length; i++)
        {
            Console.Write($"Student {i + 1}: ");
            
            for (int j = 0; j < studentMarks[i].Length; j++)
            {
                Console.Write(studentMarks[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}