/*
Scheduling Tasks
Task: Represent a weekly schedule with BitArray (7 days). Check which days are free.
*/

using System;
using System.Collections;

class Program
{
    static void Main()
    {
        BitArray schedule = new BitArray(7, true); // All days are busy
        schedule[5] = false; // Saturday is free
        schedule[6] = false; // Sunday is free


        Console.WriteLine("Free Days:");
        for (int i = 0; i < 7; i++)
        {
            if (!schedule[i]) Console.WriteLine($"Day {i + 1}");
        }
        Console.ReadKey();
    }
}
