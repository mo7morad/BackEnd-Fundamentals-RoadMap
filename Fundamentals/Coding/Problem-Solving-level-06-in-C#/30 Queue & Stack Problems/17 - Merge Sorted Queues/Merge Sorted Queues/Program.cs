// problem

/*

Merge Two Sorted Queues
Problem: Merge two sorted queues into a single sorted queue.

Example:
Input: Queue1 = [1, 3, 5], Queue2 = [2, 4, 6]
Output: Merged Queue = [1, 2, 3, 4, 5, 6]


Key Points:

Use two queues and merge their elements in sorted order.
Compare the front elements and enqueue the smaller one

*/

using System;
using System.Collections.Generic;

class Program
{
    static Queue<int> MergeQueues(Queue<int> q1, Queue<int> q2)
    {
        Queue<int> merged = new Queue<int>();


        while (q1.Count > 0 && q2.Count > 0)
        {
            if (q1.Peek() <= q2.Peek())
                merged.Enqueue(q1.Dequeue());
            else
                merged.Enqueue(q2.Dequeue());
        }

        while (q1.Count > 0)
        {
            merged.Enqueue(q1.Dequeue());
        }

        while (q2.Count > 0)
        {
            merged.Enqueue(q2.Dequeue());
        }

        return merged;
    }


    static void Main()
    {
        Queue<int> q1 = new Queue<int>(new[] { 1, 3, 5 });
        Queue<int> q2 = new Queue<int>(new[] { 2, 4, 6 });
        Queue<int> mergedQueue = MergeQueues(q1, q2);
        Console.WriteLine(string.Join(", ", mergedQueue)); // Output: 1, 2, 3, 4, 5, 6

        Console.ReadKey();

    }
}


// Another Solution


//using System;
//using System.Collections.Generic;

//class Program
//{
//    static Queue<T> MergeQueues<T>(Queue<T> q1, Queue<T> q2) where T : IComparable<T>
//    {
//        var merged = new Queue<T>();

//        // Main comparison loop
//        while (q1.Count > 0 && q2.Count > 0)
//        {
//            // If q1 is smaller or equal, dequeue q1. Otherwise dequeue q2.
//            T nextItem = (q1.Peek().CompareTo(q2.Peek()) <= 0) ? q1.Dequeue() : q2.Dequeue();
//            merged.Enqueue(nextItem);
//        }

//        // Drain remaining elements
//        Queue<T> remaining = (q1.Count > 0) ? q1 : q2;
//        while (remaining.Count > 0)
//        {
//            merged.Enqueue(remaining.Dequeue());
//        }

//        return merged;
//    }

//    static void Main()
//    {
//        var q1 = new Queue<int>(new[] { 1, 3, 5 });
//        var q2 = new Queue<int>(new[] { 2, 4, 6 });

//        var result = MergeQueues(q1, q2);
//        Console.WriteLine(string.Join(", ", result));
//    }
//}