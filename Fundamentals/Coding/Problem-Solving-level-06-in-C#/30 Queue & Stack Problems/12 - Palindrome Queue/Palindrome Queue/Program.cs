using System;
using System.Collections.Generic;

class Program
{
    static bool IsPalindrome(Queue<int> queue)
    {
        Stack<int> stack = new Stack<int>(queue);
        foreach (var item in queue)
        {
            if (stack.Pop() != item)
                return false;
        }
        return true;
    }


    static void Main()
    {
        Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 2, 1 });
        Console.WriteLine(IsPalindrome(queue)); // Output: True
    }
}


// -----------------------------------------------------------
// Another Solution
// -----------------------------------------------------------


//using System;
//using System.Collections.Generic;

//class Program
//{

//    public static bool IsPalindromeQueue(Queue<int> q)
//    {
//        Stack<int> stack = new Stack<int>();

//        for (int i = 0; i < q.Count; i++)
//        {
//            int element = q.Dequeue();
//            stack.Push(element);
//            q.Enqueue(element);
//        }

//        // Second pass: compare
//        for (int i = 0; i < q.Count; i++)
//        {
//            int fromQueue = q.Dequeue();
//            int fromStack = stack.Pop();

//            if (fromQueue != fromStack)
//                return false;
//        }

//        return true;
//    }




//    static void Main()
//    {
//        Queue<int> myQueue = new Queue<int>();
//        int[] myQueueElemetns = { 1, 2, 3, 2, 1 };

//        foreach (int num in myQueueElemetns)
//        {
//            myQueue.Enqueue(num);
//        }

//        bool result = IsPalindromeQueue(myQueue);
//        Console.WriteLine(result ? "The queue is a palindrome." : "The queue is not a palindrome.");
//    }
//}