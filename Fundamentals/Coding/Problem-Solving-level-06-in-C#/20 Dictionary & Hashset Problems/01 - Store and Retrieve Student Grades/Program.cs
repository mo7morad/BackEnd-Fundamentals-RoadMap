/*
Store and Retrieve Student Grades
Problem: Store the grades of students using their names as keys, and retrieve Bob's Info using student name.

Output: Student: Bob, Grade: 90
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> studentGrades = new Dictionary<string, double>
        {
            { "Alice", 85.5 },
            { "Bob", 90.0 },
            { "Charlie", 78.5 }
        };
        
        Console.WriteLine($"Student: Bob, Grade:" + studentGrades["Bob"]);
        Console.ReadKey();
        // Output:
        // Student: Bob, Grade: 90
    }
}

