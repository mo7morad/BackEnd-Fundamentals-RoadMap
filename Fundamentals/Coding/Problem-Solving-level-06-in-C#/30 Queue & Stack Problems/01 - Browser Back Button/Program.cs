using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> history = new Stack<string>();
        history.Push("Page1");
        history.Push("Page2");
        history.Push("Page3");

        Console.WriteLine("Back from: " + history.Pop()); // Output: Back from: Page3
        Console.WriteLine("Current Page: " + history.Peek()); // Output: Current Page: Page2
        Console.ReadKey();
    }
}

