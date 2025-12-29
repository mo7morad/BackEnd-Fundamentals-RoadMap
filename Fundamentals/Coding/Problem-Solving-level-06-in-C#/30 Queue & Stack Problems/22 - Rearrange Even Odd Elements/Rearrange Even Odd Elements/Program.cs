/*

using System.Runtime.Intrinsics.X86;

Rearrange Even and Odd Elements
Problem: Rearrange a queue such that all even numbers appear before odd numbers while maintaining their order.


Example:
Input: Queue = [1, 2, 3, 4, 5, 6]
Output: Queue = [2, 4, 6, 1, 3, 5]


Key Points:

Use two additional queues to separate even and odd elements.
Combine them back into the original queue.

*/



using System;
using System.Collections.Generic;

class Program
{
    // Changed signature to use List<int>
    public static List<int> RearrangeEvenOdd(Queue<int> input)
    {

        List<int> evens = new List<int>(); 
        List<int> odds = new List<int>();

        foreach (int number in input)
        {
            if (number % 2 == 0)
            {
                evens.Add(number);
            }
            else
            {
                odds.Add(number);
            }
        }

        // 3. THE "CHUNK" (AddRange), Instead of a loop that goes "Add... Add... Add...", 
        evens.AddRange(odds);

        return evens;
    }

    static void Main()
    {
        Queue<int> inputQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });
        
        List<int> outputList = RearrangeEvenOdd(inputQueue);
        
        Console.WriteLine(string.Join(", ", outputList));  // Output: 2, 4, 6, 1, 3, 5
    }
}





// Another Solution

/* 

using System;
using System.Collections.Generic;

class Program
{
    // Fixed typo: Rearrage -> Rearrange
    public static Queue<int> RearrangeEvenOdd(Queue<int> input)
    {
        Queue<int> evenQueue = new Queue<int>();
        Queue<int> oddQueue = new Queue<int>();

        // 1. Drain the input queue completely to separate items
        while (input.Count > 0)
        {
            int number = input.Dequeue();
            if (number % 2 == 0)
            {
                evenQueue.Enqueue(number);
            }
            else
            {
                oddQueue.Enqueue(number);
            }
        }

        // 2. Refill the original 'input' queue with Evens first
        while (evenQueue.Count > 0)
        {
            input.Enqueue(evenQueue.Dequeue());
        }

        // 3. Then append the Odds
        while (oddQueue.Count > 0)
        {
            input.Enqueue(oddQueue.Dequeue());
        }

        // The 'input' object is now modified and sorted
        return input;
    }

    static void Main()
    {
        // Using 'var' is cleaner in modern C#
        var inputQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });
        
        var outputQueue = RearrangeEvenOdd(inputQueue);
        
        Console.WriteLine(string.Join(", ", outputQueue));
        // Output: 2, 4, 6, 1, 3, 5
    }
}

*/

