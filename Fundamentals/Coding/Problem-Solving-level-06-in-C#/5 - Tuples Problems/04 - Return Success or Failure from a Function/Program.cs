/*
Return Success or Failure from a Function
Problem: Write a function that check the student mark and returns success status and the mark value.
*/

using System;

class Program
{
    static (bool Success, int Value) CheckStudentStatus(int grade)
    {
        bool success= grade >= 50? true : false;
        return (success, grade);
    }
    static void Main()
    {
        var result = CheckStudentStatus(55);
        Console.WriteLine($"Success: {result.Success}, Value: {result.Value}");
        // Output: Success: True, Value: 55
        Console.ReadKey();
    }
}