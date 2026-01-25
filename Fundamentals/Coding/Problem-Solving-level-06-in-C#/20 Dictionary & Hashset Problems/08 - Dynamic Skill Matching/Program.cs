/*
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
        HashSet<string> candidateSkills = new HashSet<string>
        {
            "C#",
            "SQL",
            "JavaScript"
        };

        HashSet<string> jobRequirements = new HashSet<string>
        {
            "C#",
            "JavaScript",
            "React"
        };

        candidateSkills.IntersectWith(jobRequirements);

        Console.WriteLine("Matching Skills: " + string.Join(", ", candidateSkills));
        // Output: Matching Skills: C#, JavaScript
    }
}