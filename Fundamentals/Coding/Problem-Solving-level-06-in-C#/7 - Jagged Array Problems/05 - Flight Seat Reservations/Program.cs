/*
Flight Seat Reservations
Problem: Store seat availability for multiple flights where each flight has a different number of seats.
*/

using System;
class Program
{
    static void Main()
    {
        bool[][] flightSeats = new bool[2][];
        flightSeats[0] = new bool[] { true, false, true }; // Flight 1
        flightSeats[1] = new bool[] { false, false, true, true }; // Flight 2


        Console.WriteLine("Seat Availability:");
        for (int i = 0; i < flightSeats.Length; i++)
        {
            Console.Write($"Flight {i + 1}: ");
            Console.WriteLine(string.Join(", ", productSales[i]));
        }
    }
}

// Output:
// Flight 1: Available Occupied Available
// Flight 2: Occupied Occupied Available Available