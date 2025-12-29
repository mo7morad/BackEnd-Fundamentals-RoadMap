/*

Find Middle Element in a Queue
Problem: Find the middle element of a queue without modifying it.

Example:
Input: Queue = [1, 2, 3, 4, 5]
Output: 3


Key Points:

Use a list to access the middle index.

*/


using System;
using System.Collections.Generic;

class Program
{

    static int? FindMiddleElement(Queue<int> queue)
    {
        int count = queue.Count;
        if (count == 0 || count % 2 == 0)
            return null;

        return queue.ElementAt(count / 2);
    }


    static void Main()
    {
        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine(FindMiddleElement(queue)); // Output: 3
    }
}
