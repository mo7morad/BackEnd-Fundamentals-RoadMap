/*
Phonebook Application
Problem: Implement a phonebook where you can store and retrieve contact numbers using names.

Output:

Alice's Phone: 123-456-7890

Bob's Phone: 987-654-3210
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>
        {
            { "Alice", "123-456-7890" },
            { "Bob", "987-654-3210" }
        };


        Console.WriteLine($"Alice's Phone: {phonebook["Alice"]}");
        Console.WriteLine($"Bob's Phone: {phonebook["Bob"]}");
        Console.ReadKey();
        // Output:
        // Alice's Phone: 123-456-7890
        // Bob's Phone: 987-654-3210
    }
}
