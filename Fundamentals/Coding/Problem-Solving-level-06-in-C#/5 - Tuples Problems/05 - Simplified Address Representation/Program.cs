/*
Simplified Address Representation
Problem: Use tuples to represent and display a person's address.

Output: Address: 123 Main St, Springfield, IL, 62704
*/

using System;
class Program
{
    static void Main()
    {
        var address = (Street: "123 Main St", City: "Springfield", State: "IL", Zip: "62704");
        Console.WriteLine($"Address: {address.Street}, {address.City}, {address.State}, {address.Zip}");
        // Output: Address: 123 Main St, Springfield, IL, 62704
        Console.ReadKey();
    }
}
