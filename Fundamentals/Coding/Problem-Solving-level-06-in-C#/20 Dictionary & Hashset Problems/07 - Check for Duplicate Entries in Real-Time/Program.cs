/*
Check for Duplicate Entries in Real-Time
Problem: Detect duplicates as data is added.

Dynamic Skill Matching
Problem: Match a candidate’s skills to a job’s required skills.

Input:

candidateSkills = { "C#", "SQL", "JavaScript" }

jobRequirements = { "C#", "JavaScript", "React" }

Output: Matching Skills: C#, JavaScript
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> unique = new HashSet<string>();

        string[] entries = { "apple", "banana", "orange", "apple", "grape", "banana" };
        foreach (var entry in entries)
        {
            if (!unique.Add(entry))
            {
                Console.WriteLine($"Duplicate found: {entry}");
            }
        }
    }
}