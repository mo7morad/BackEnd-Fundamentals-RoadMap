/*
Return Multiple Values from a Function
Problem: Create a function that returns a student's name, age, and grade.
*/

using System;
class Program
{
    static (string Name, int Age, double Grade) GetStudentDetails()
    {
        return ("Alice", 20, 85.5);
    }

    static void Main()
    {
        var student = GetStudentDetails();
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        // Output: Name: Alice, Age: 20, Grade: 85.5
        Console.ReadKey();
    }
}
