/*
Sort and Remove Duplicates from a List
Description: Given a list with duplicate values, use a SortedSet to remove duplicates and sort it.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Original list with duplicates
        List<int> numbers = new List<int> { 5, 3, 8, 3, 1, 5, 7, 2, 8, 4 };

        // Using SortedSet to remove duplicates and sort the list
        SortedSet<int> sortedSet = new SortedSet<int>(numbers);

        // Converting back to a list if needed
        List<int> sortedList = new List<int>(sortedSet);

        // Displaying the sorted list without duplicates
        Console.WriteLine("Sorted List without Duplicates:");
        foreach (int number in sortedList)
        {
            Console.WriteLine(number);
        }
    }
}