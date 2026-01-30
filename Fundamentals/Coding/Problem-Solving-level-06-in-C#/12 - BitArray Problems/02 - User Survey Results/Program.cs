/*
User Survey Results
Task: Store the responses of 5 questions (Yes/No) for a survey of 10 users.
*/

using System;
using System.Collections;

class Program
{
    static void Main()
    {
        BitArray surveyResponses = new BitArray(5); // 5 questions


        // User 1 responses: Yes, No, Yes, Yes, No
        surveyResponses[0] = true; // Question 1
        surveyResponses[1] = false; // Question 2
        surveyResponses[2] = true; // Question 3
        surveyResponses[3] = true; // Question 4
        surveyResponses[4] = false; // Question 5

        for (int i = 0; i < surveyResponses.Length; i++)
        {
            Console.WriteLine($"User {i+1}, Question {i + 1}: {surveyResponses[i]}"); 
        }
        Console.ReadKey();
    }   
}