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

      Dictionary<string, int> Students = new Dictionary<string, int>();
      Students.Add("Alice", 85);
      Students.Add("Bob", 90);

      int bobGrade = Students["Bob"];
      Console.WriteLine("Student: Bob, Grade: " + bobGrade);
    }
}
