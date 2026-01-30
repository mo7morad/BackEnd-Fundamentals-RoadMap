/*
Perform Bitwise AND Between Two BitArrays
Description:
Write a function that takes two BitArray objects of equal length and returns a new BitArray that is
the result of a bitwise AND operation.
*/

/*
Perform Bitwise AND Between Two BitArrays
Description: Manual implementation using a loop.
*/


using System;
using System.Collections;

class Program
{
    static BitArray PerformAND(BitArray bits1, BitArray bits2)
    {
        if (bits1.Length != bits2.Length)
            throw new ArgumentException("BitArrays must have the same length!");
            
        return bits1.And(bits2);
    }

    static void Main()
    {
        BitArray bits1 = new BitArray(new bool[] { true, false, true });
        BitArray bits2 = new BitArray(new bool[] { true, true, false });

        BitArray result = PerformAND(bits1, bits2);

        Console.Write("Result of AND operation: ");
        foreach (bool bit in result)
        {
            Console.Write(bit + " ");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}