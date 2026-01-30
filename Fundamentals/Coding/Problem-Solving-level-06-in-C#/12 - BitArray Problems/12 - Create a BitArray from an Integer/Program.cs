/*

Create a BitArray from an Integer
Description: Write a function that takes an integer and returns a BitArray representing its binary digits.
*/

using System;
using System.Collections;

class Program
{
    static BitArray IntToBitArray(int number)
    {
        return new BitArray(new[] { number });
    }


    static void Main()
    {
        int number = 10; // Binary: 1010
        BitArray bits = IntToBitArray(number);


        Console.Write("BitArray representation of " + number + ": ");
        bool leadingZero = true; // To suppress leading zeros
        for (int i = bits.Length - 1; i >= 0; i--)
        {
            if (bits[i])
            {
                leadingZero = false;
            }
            if (!leadingZero)
            {
                Console.Write(bits[i] ? "1" : "0");
            }
        }


        // In case the number is 0, print a single "0"
        if (leadingZero)
        {
            Console.Write("0");
        }


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
