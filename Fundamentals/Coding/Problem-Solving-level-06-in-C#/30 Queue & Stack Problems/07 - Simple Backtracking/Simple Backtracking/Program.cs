using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Start -> Go to Gaz Station -> Go to Super Market -> Go To Work -> Go to Cafe -> Go Home.\n");

        Stack<string> BackTracing = new Stack<string>();
        BackTracing.Push("Start");
        BackTracing.Push("Go to Gaz Station");
        BackTracing.Push("Go to Super Market");
        BackTracing.Push("Go To Work");
        BackTracing.Push("Go to Cafe");
        BackTracing.Push("Go Home");

        Console.WriteLine("BackTracing Your Journey:\n");
        while (BackTracing.Count > 0)
        {
            string step = BackTracing.Pop();
            Console.WriteLine(step);
        }
    }
}

