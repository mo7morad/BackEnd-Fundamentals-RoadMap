using System;
using System.Collections.Generic;


class CustomerService
{
    static void Main()
    {
        Queue<string> customers = new Queue<string>();
        customers.Enqueue("Customer1");
        customers.Enqueue("Customer2");
        customers.Enqueue("Customer3");


        Console.WriteLine("Serving customers:\n");


        while (customers.Count > 0)
        {
            Console.WriteLine($"Serving: {customers.Dequeue()}");
        }
        Console.ReadKey();
    }
}