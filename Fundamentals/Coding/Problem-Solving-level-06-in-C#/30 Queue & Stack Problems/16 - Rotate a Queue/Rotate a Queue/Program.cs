using System;
using System.Collections.Generic;

class Program
{
    public static Queue<T> RotateQueue<T>(Queue<T> queue, int k)
    {
        if (queue == null || queue.Count == 0 || k <= 0)
        {
            return queue;
        }
        int rotations = k % queue.Count;
        for (int i = 0; i < rotations; i++)
        {
            T item = queue.Dequeue();
            queue.Enqueue(item);
        }
        return queue;
    }
    static void Main()
    {
        // Example usage
        Queue<int> myQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
        int k = 2;
        Queue<int> rotatedQueue = RotateQueue(myQueue, k);
        Console.WriteLine(string.Join(", ", rotatedQueue)); // Output: 3, 4, 5, 1, 2

    }
}


// Another Solution

//class Program
//{
//    static Queue<int> RotateQueue(Queue<int> queue, int k)
//    {
//        for (int i = 0; i < k; i++)
//        {
//            queue.Enqueue(queue.Dequeue());
//        }
//        return queue;
//    }


//    static void Main()
//    {
//        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
//        Queue<int> rotatedQueue = RotateQueue(queue, 2);
//        Console.WriteLine(string.Join(", ", rotatedQueue)); // Output: 3, 4, 5, 1, 2
//        Console.ReadKey();
//    }
//}