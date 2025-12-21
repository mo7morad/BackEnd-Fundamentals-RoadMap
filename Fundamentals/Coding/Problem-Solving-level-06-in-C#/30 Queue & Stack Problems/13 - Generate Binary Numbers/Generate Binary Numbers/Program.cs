using System;
using System.Collections.Generic;


class Program
{
    static void GenerateBinaryNumbers(int n)
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1");


        for (int i = 0; i < n; i++)
        {
            string binary = queue.Dequeue();
            Console.WriteLine(binary);
            queue.Enqueue(binary + "0");
            queue.Enqueue(binary + "1");
        }
    }


    static void Main()
    {
        GenerateBinaryNumbers(5);
        // Output: 1, 10, 11, 100, 101
    }
}
