using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Initialize a queue to represent ticket numbers
        Queue<int> ticketQueue = new Queue<int>();


        // Simulate ticket generation
        for (int i = 101; i <= 105; i++)
        {
            ticketQueue.Enqueue(i);
            Console.WriteLine($"Ticket {i} issued.");
        }


        Console.WriteLine("\nTicketing System Simulation Started...\n");


        // Process tickets in the queue
        while (ticketQueue.Count > 0)
        {
            int currentTicket = ticketQueue.Dequeue();
            Console.WriteLine($"Processing Ticket: {currentTicket}");


            // Display remaining tickets in the queue
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine("Remaining Tickets: " + string.Join(", ", ticketQueue));
            }
            else
            {
                Console.WriteLine("No more tickets in the queue.");
            }


            Console.WriteLine();
        }


        Console.WriteLine("Ticketing System Simulation Ended.");
        Console.ReadKey();
    }
}

