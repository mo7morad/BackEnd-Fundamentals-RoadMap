using System;
using System.Collections.Generic;


class MyQueue
{
    private Stack<int> stack1 = new Stack<int>();
    private Stack<int> stack2 = new Stack<int>();
    public void Enqueue(int x)
    {
        stack1.Push(x);
    }
    public int Dequeue()
    {
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
        return stack2.Pop();
    }


    public bool IsEmpty()
    {
        return stack1.Count == 0 && stack2.Count == 0;
    }
}


class Program
{
    static void Main()
    {
        MyQueue queue = new MyQueue();
        int[] myList = new int[] {1,2,3,4,5 };
        foreach (var item in myList)
        {
            queue.Enqueue(item);
        }
        Console.WriteLine(queue.Dequeue()); // Output: 1
        Console.WriteLine(queue.Dequeue()); // Output: 2
        Console.WriteLine(queue.Dequeue()); // Output: 3
    }
}