using System;
using System.Collections.Generic;

class Program
{
    static void InterleaveQueue(Queue<int> queue)
    {
        int halfSize = queue.Count / 2;
        
        // Step 1: Move first half to a temporary queue
        Queue<int> firstHalf = new Queue<int>();
        for (int i = 0; i < halfSize; i++)
        {
            firstHalf.Enqueue(queue.Dequeue());
        }
        
        // Step 2: Now queue contains second half, firstHalf contains first half
        // Interleave: take one from firstHalf, then one from queue (second half)
        while (firstHalf.Count > 0)
        {
            queue.Enqueue(firstHalf.Dequeue()); // from first half
            queue.Enqueue(queue.Dequeue());      // from second half
        }
    }


    static void Main()
    {
        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });
        InterleaveQueue(queue);
        Console.WriteLine(string.Join(", ", queue)); // Output: 1, 4, 2, 5, 3, 6
        Console.ReadKey();
    }
}