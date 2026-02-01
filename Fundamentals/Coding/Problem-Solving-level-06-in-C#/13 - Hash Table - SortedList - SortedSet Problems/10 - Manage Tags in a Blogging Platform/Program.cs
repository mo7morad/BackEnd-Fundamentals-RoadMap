/*
Manage Tags in a Blogging Platform
Description: In a blogging platform, authors can add tags to their posts.
Maintain a list of all unique tags in alphabetical order.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<string> tags = new SortedSet<string>
        {
            "C#", "Programming", "Tutorial", "DotNet"
        };

        // Add more tags
        tags.Add("Coding");
        tags.Add("Programming"); // Duplicate, won't be added

        Console.WriteLine("All Tags:");
        foreach (var tag in tags)
        {
            Console.WriteLine(tag);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
