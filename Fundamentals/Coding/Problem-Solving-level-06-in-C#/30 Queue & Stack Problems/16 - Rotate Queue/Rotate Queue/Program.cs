// problem

/*
 
* Rotate a Queue
Problem: Rotate a queue by K positions.

Example:
Input: Queue = [1, 2, 3, 4, 5], K = 2
Output: Queue = [3, 4, 5, 1, 2]


Key Points:

Dequeue K elements and enqueue them back.
*/


using System;
using System.Collections.Generic;


class Program
{
    static Queue<int> RotateQueue(Queue<int> queue, int k)
    {
        for (int i = 0; i < k; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
        return queue;
    }


    static void Main()
    {
        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
        Queue<int> rotatedQueue = RotateQueue(queue, 2);
        Console.WriteLine(string.Join(", ", rotatedQueue)); // Output: 3, 4, 5, 1, 2
        Console.ReadKey();
    }
}


