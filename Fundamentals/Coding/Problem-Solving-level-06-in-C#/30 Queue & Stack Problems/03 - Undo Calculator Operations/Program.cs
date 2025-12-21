using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> calculatorStack = new Stack<int>();
        calculatorStack.Push(10);
        calculatorStack.Push(20);
        calculatorStack.Push(30);


        Console.WriteLine("Undo: " + calculatorStack.Pop()); // Output: Undo: 30
        Console.WriteLine("Current Result: " + calculatorStack.Peek()); // Output: Current Result: 20
        Console.ReadKey();
    }
}

