/*
Manage Meeting Times for a Calendar
Description: Automatically organize meeting times chronologically for a daily calendar.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<TimeSpan> meetingTimes = new SortedSet<TimeSpan>
        {
            new TimeSpan(14, 0, 0), // 2:00 PM
            new TimeSpan(9, 30, 0), // 9:30 AM
            new TimeSpan(11, 0, 0)  // 11:00 AM
        };

        Console.WriteLine("Today's meetings (sorted):");
        foreach (var time in meetingTimes)
        {
            Console.WriteLine(time);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}