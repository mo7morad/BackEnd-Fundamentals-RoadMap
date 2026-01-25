using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> uniqueVisitors = new HashSet<string>();

        // Simulate website visitors
        uniqueVisitors.Add("192.168.1.1");
        uniqueVisitors.Add("192.168.1.2");
        uniqueVisitors.Add("192.168.1.1"); // Duplicate

        Console.WriteLine("Unique Visitors: " + uniqueVisitors.Count);
        // Output: Unique Visitors: 2
    }
}