// Real-Time Notification System
// Problem: Display notifications about your order dynamically as they arrive.


using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main()
    {
        ObservableCollection<string> notifications = new ObservableCollection<string>();
        notifications.CollectionChanged += (sender, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine($"New Notification: {e.NewItems[0]}");
        };

        notifications.Add("Your order is under processing.");
        notifications.Add("Your order has been shipped.");
        notifications.Add("Your order is Delivered.");
        Console.ReadKey();
    }
}