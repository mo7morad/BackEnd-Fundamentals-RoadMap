/*
Optimizing Space in Large Data
Task: Use BitArray to track which seats (1,000 seats) in a theater are booked.
*/

using System;
using System.Collections;

class Program
{
    static void Main()
    {
        BitArray seats = new BitArray(1000, false); // All seats unbooked
        seats[100] = true; // Seat 101 booked
        seats[999] = true; // Seat 1000 booked

        Console.WriteLine($"Seat 101 booked: {seats[100]}"); // Output: True
        Console.WriteLine($"Seat 1000 booked: {seats[999]}"); // Output: True
        Console.ReadKey();
    }

}