// problem

/*

Implement a Priority Queue
Problem: Implement a priority queue where elements with higher priority are dequeued first.

Example:
Input: Enqueue(10, 1), Enqueue(5, 3), Enqueue(20, 2), Dequeue()
Output: 5 (highest priority first)


Key Points:

Use a sorted data structure like a SortedList or a SortedDictionary to maintain priorities.
Dequeue elements based on the priority value.

*/



public class MyPriorityQueue
{
    // Key = Priority, Value = Queue of items with that priority
    SortedDictionary<int, Queue<int>> pq = new SortedDictionary<int, Queue<int>>();

    public void Enqueue(int item, int priority)
    {
        // If priority doesn't exist, add it with a new Queue
        if (!pq.ContainsKey(priority))
        {
            pq[priority] = new Queue<int>();
        }

        // if it exists, add the item to the queue with same priority
        pq[priority].Enqueue(item);
    }

    public int Dequeue()
    {
        if (pq.Count == 0) throw new InvalidOperationException("Queue is empty");


        int highestPriority = pq.Keys.Last();

        // Get the item from that priority's queue
        int item = pq[highestPriority].Dequeue();

        // If that priority bucket is now empty, remove the Key entirely
        if (pq[highestPriority].Count == 0)
        {
            pq.Remove(highestPriority);
        }

        return item;
    }
}


class Program
{
    static void Main()
    {
        MyPriorityQueue pq = new MyPriorityQueue();
        pq.Enqueue(10, 3);
        pq.Enqueue(5, 1);
        pq.Enqueue(20, 2);
        Console.WriteLine(pq.Dequeue()); // Output: 10
        Console.WriteLine(pq.Dequeue()); // Output: 20
    }
}

