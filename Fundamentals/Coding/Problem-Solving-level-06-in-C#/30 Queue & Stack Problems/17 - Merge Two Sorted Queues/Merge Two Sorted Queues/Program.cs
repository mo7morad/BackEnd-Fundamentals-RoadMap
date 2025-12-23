using System;
using System.Collections.Generic;

class Program
{

    public static Queue<int> MergeSortedQueues(Queue<int> q1, Queue<int> q2)
    {
        Queue<int> mergedQueue = new Queue<int>();

        while (q1.Count > 0 && q2.Count > 0)
        {
            if (q1.Peek() <= q2.Peek())
                mergedQueue.Enqueue(q1.Dequeue());
            else
                mergedQueue.Enqueue(q2.Dequeue());
        }

        // Add remaining elements
        while (q1.Count > 0)
            mergedQueue.Enqueue(q1.Dequeue());

        while (q2.Count > 0)
            mergedQueue.Enqueue(q2.Dequeue());

        return mergedQueue;
    }

    static void Main()
    {
        // Test Example

        Queue<int> q1 = new Queue<int>(new[] { 1, 3, 5 });
        Queue<int> q2 = new Queue<int>(new[] { 2, 4, 6 });
        Queue<int> mySortedQueue = MergeSortedQueues(q1, q2);

        Console.WriteLine("The result sorted Queue: ");
        foreach(int item in mySortedQueue)
        {
            Console.Write(item + "  ");
        }
    }
}


// Another Solution


using System;
//using System.Collections.Generic;
//using System.Linq;

//public class Merge
//{
//    static void Main(string[] Args)
//    {
//        Queue<int> Queue1 = new Queue<int>(new[] { 1, 3, 5 });
//        Queue<int> Queue2 = new Queue<int>(new[] { 2, 4, 6 });

//        Queue<int> MergedQueue = new(Queue1.Concat(Queue2).OrderBy(x => x));

//        Console.WriteLine(string.Join(" ", MergedQueue));
//    }
//}