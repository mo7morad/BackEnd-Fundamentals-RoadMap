using System;
using System.Collections.Generic;

class Program
{
    static string DecimalToBinary(int number)
    {
        Stack<int> stack = new Stack<int>();

        while (number > 0)
        {
            stack.Push(number % 2);
            number /= 2;
        }

        return string.Join("", stack);
    }

    static void Main()
    {
        Console.WriteLine(DecimalToBinary(10)); // Output: 1010
        Console.WriteLine(DecimalToBinary(7)); // Output: 111
        Console.WriteLine(DecimalToBinary(9)); // Output: 1001
        Console.ReadKey();
    }
}
