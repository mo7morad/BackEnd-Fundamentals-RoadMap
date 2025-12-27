// problem

/*

Rearrange Queue Alternately
Problem: Rearrange elements in a queue alternately in increasing and decreasing order.

Example:
Input: Queue = [1, 2, 3, 4, 5, 6]
Output: Queue = [1, 6, 2, 5, 3, 4]
Key Points:

Split the queue into two halves.
Merge the halves alternately.

*/


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

