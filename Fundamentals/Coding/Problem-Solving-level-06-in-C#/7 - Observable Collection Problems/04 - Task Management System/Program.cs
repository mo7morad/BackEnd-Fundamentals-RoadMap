/*
Task Management System
Problem: Manage a list of tasks dynamically, allowing addition, removal, and status updates.
*/

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main()
    {
        ObservableCollection<string> tasks = new ObservableCollection<string>();
        tasks.CollectionChanged += (sender, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine($"Task Added: {e.NewItems[0]}");
            if (e.Action == NotifyCollectionChangedAction.Remove)
                Console.WriteLine($"Task Removed: {e.OldItems[0]}");
        };

        tasks.Add("Complete report");
        tasks.Add("Attend meeting");
        tasks.Remove("Complete report");
        // Output:
        // Task Added: Complete report
        // Task Added: Attend meeting
        // Task Removed: Complete report
        Console.ReadKey();
    }
}