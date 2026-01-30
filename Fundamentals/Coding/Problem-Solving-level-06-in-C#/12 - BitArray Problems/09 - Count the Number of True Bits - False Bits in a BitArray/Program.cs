/*
Count the Number of True Bits / False Bits in a BitArray
Description:Write a function to count the number of true values and false values in a BitArray.
*/

using System;
using System.Collections;


class Program
{
    static int CountTrueBits(BitArray bits)
    {
        int count = 0;
        foreach (bool bit in bits)
        {
            if (bit) count++;
        }
        return count;
    }


    static int CountFalseBits(BitArray bits)
    {
        int count = 0;
        foreach (bool bit in bits)
        {
            if (!bit) count++;
        }
        return count;
    }


    static void Main()
    {
        BitArray bits = new BitArray(new bool[] { true, false, true, true, false });
        Console.WriteLine("Number of true bits: " + CountTrueBits(bits));
        Console.WriteLine("Number of false bits: " + CountFalseBits(bits));
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
