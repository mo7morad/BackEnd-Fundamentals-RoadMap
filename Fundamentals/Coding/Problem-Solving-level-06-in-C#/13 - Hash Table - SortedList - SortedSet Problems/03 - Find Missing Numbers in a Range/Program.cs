/*
Find Missing Numbers in a Range
Description: Given a range of numbers, find the missing numbers by comparing with a SortedSet.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<int> numbers = new SortedSet<int> { 1, 2, 4, 5, 7 };

        for (int i = 1; i <= numbers.Max; i++)
        {
            if (!numbers.Contains(i))
            {
                Console.WriteLine($"Missing number: {i}");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

