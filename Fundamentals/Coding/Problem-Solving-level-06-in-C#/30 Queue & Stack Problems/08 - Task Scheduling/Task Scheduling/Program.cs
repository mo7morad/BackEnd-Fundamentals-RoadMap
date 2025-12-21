using System;
using System.Collections.Generic;


class TaskScheduling
{
    static void Main()
    {
        Queue<string> tasks = new Queue<string>();
        tasks.Enqueue("Task1");
        tasks.Enqueue("Task2");
        tasks.Enqueue("Task3");
        tasks.Enqueue("Task4");


        Console.WriteLine("Executing tasks:");

        while (tasks.Count > 0)
        {
            string currentTask = tasks.Dequeue();
            Console.WriteLine($"Processing: {currentTask}");
        }
    }
}