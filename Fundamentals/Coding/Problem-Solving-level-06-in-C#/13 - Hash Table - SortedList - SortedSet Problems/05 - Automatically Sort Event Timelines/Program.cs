/*
Automatically Sort Event Timelines
Description: Maintain a sorted timeline of events by their occurrence times to show the upcoming ones first.
*/

using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        SortedSet<DateTime> eventTimeline = new SortedSet<DateTime>
        {
            new DateTime(2024, 12, 25),
            new DateTime(2024, 11, 30),
            new DateTime(2025, 1, 1)
        };


        Console.WriteLine("Upcoming events:");
        foreach (var eventTime in eventTimeline)
        {
            Console.WriteLine(eventTime.ToShortDateString());
        }


        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}