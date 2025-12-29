/*

Clone a Queue Without Using Extra Space
Problem: Clone a queue such that the original queue remains unchanged.

Example:
Input: Queue = [1, 2, 3, 4]
Output: Clone = [1, 2, 3, 4]


Key Points:

Use recursion to clone the queue while keeping the original intact.

*/

using System;
using System.Collections.Generic;


class Program
{
    public static Queue<int> CloneQueue = new Queue<int>();
    public static Queue<int> Clone(Queue<int> queue)
    {

        int Value = queue.Dequeue();
        queue.Enqueue(Value);
        CloneQueue.Enqueue(Value);

        if (CloneQueue.Count != queue.Count)
            Clone(queue);

        return CloneQueue;
    }

    static void Main()
    {
        Queue<int> queue = new Queue<int>(new int[] { 1, 2, 3, 4, 5, 6 });
        Queue<int> CloneQueue = Clone(queue);

        Console.WriteLine("Original Queue:");
        Console.WriteLine(string.Join(",", queue));

        Console.WriteLine("Cloned Queue:");
        Console.WriteLine(string.Join(",", CloneQueue));
    }
}
