// problem

/*
 
Queue Using Two Stacks
Problem: Implement a queue using two stacks.

Example:
Operations: Enqueue(1), Enqueue(2), Dequeue(), Dequeue()
Output: 1 , 2


Key Points:

Use one stack to store incoming elements and the other for dequeuing. 
 
*/


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
        queue.Enqueue(1);
        queue.Enqueue(2);
        Console.WriteLine(queue.Dequeue()); // Output: 1
        Console.WriteLine(queue.Dequeue()); // Output: 2
    }
}