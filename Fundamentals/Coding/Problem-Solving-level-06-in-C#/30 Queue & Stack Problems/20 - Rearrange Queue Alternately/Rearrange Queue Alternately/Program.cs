//using System;
//using System.Collections.Generic;

//class Program
//{
//    public static Queue<int> MergeAlternately(Queue<int> queue1)
//    {
//        int splitCount = queue1.Count;
//        Queue<int> queue2 = new Queue<int>();
//        for (int i = 0; i < splitCount / 2; i++)
//        {
//            queue2.Enqueue(queue1.Dequeue());
//        }
//        Queue<int> mergedQueue = new Queue<int>();
//        while (queue1.Count > 0 || queue2.Count > 0)
//        {
//            if (queue2.Count > 0)
//            {
//                mergedQueue.Enqueue(queue2.Dequeue());
//            }
//            if (queue1.Count > 0)
//            {
//                mergedQueue.Enqueue(queue1.Dequeue());
//            }
//        }
//        return mergedQueue;

//    }
//    static void Main()
//    {
//        // Example usage:
//        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });
//        Queue<int> rearrangedQueue = MergeAlternately(queue);
//        Console.WriteLine("Rearranged Queue:");
//        while (rearrangedQueue.Count > 0)
//        {
//            Console.Write(rearrangedQueue.Dequeue() + " ");
//        }
//    }
//}



//Another Solution

using System;
using System.Collections.Generic;


class Program
{
    static Queue<int> RearrangeAlternately(Queue<int> queue)
    {
        List<int> list = new List<int>(queue);
        int n = list.Count;
        Queue<int> result = new Queue<int>();

        for (int i = 0; i < n / 2; i++)
        {
            result.Enqueue(list[i]);
            result.Enqueue(list[n - i - 1]);
        }

        if (n % 2 != 0)
        {
            result.Enqueue(list[n / 2]);
        }

        return result;
    }


    static void Main()
    {
        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 });
        Queue<int> rearrangedQueue = RearrangeAlternately(queue);
        Console.WriteLine(string.Join(", ", rearrangedQueue)); // Output: 1, 6, 2, 5, 3, 4
        Console.ReadKey();
    }
}
