using System;
using System.Collections.Generic;

class Program
{

    public static Queue<int> SortQueueAsc(Queue<int> q)
    {
        List<int> myList = new List<int>(q);
        myList.Sort();
        return new Queue<int>(myList);
    }


    static void Main()
    {
        Queue<int> myUnorderdQueue = new Queue<int>(new int[] {5, 4, 7, 3, 2, 1, 6});
        SortQueueAsc(myUnorderdQueue);

        Console.WriteLine("The unordered Queue: ");
        foreach(int num in myUnorderdQueue)
        {
            Console.Write(num + "   ");
        }

        Queue<int> myOrderedQueue = SortQueueAsc(myUnorderdQueue);
        Console.WriteLine("\nThe ordered Queue");
        foreach (int num in myOrderedQueue)
        {
            Console.Write(num + "   ");
        }
    }
}


// ---------------------------------
//         Another Solution
// ---------------------------------

//using System;
//using System.Collections.Generic;


//class Program
//{
//    static Queue<int> SortQueue(Queue<int> queue)
//    {
//        //this will generate a list from a queue
//        List<int> list = new List<int>(queue);
//        list.Sort();


//        // this will generate a queue from list
//        return new Queue<int>(list);
//    }


//    static void Main()
//    {
//        Queue<int> queue = new Queue<int>(new[] { 5, 1, 3, 2, 4 });
//        Queue<int> sortedQueue = SortQueue(queue);
//        Console.WriteLine(string.Join(", ", sortedQueue)); // Output: 1, 2, 3, 4, 5


//        Console.ReadKey();
//    }
