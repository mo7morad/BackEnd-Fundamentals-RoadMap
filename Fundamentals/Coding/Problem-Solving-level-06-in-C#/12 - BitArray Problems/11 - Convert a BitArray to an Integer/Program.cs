/*
Convert a BitArray to an Integer
Description:
Write a function to convert a BitArray (representing binary digits) into an integer.
*/

using System;
using System.Collections;

class Program
{
    static int BitArrayToInt(BitArray bits)
    {
        int result = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i])
            {
                result += (1 << i); // Add the value of the current bit
            }
        }
        return result;
    }

    static int BitArrayToInt_Pro(BitArray bits)
    {
    // Create an integer array of size 1 (to hold the result)
    int[] array = new int[1];

    // Copy the bits from BitArray directly into the integer array starting at index 0
    bits.CopyTo(array, 0);

    // Return the integer value
    return array[0];
    }

    static void Main()
    {
        BitArray bits = new BitArray(new bool[] { true, false, true }); // Binary: 101
        int number = BitArrayToInt(bits);
        Console.WriteLine("Integer value of BitArray: " + number);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}