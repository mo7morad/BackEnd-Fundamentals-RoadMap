using System;
using System.Collections.Generic;


class WebServer
{
    static void Main()
    {
        Queue<string> requests = new Queue<string>();
        requests.Enqueue("Request1");
        requests.Enqueue("Request2");
        requests.Enqueue("Request3");

        Console.WriteLine("Processing web requests:\n");
        while (requests.Count > 0)
        {
            Console.WriteLine($"Processed: {requests.Dequeue()}");
        }
    }
}