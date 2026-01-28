// Dynamic Weather Updates
// Problem: Display a dynamic list of weather updates for different cities.


using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main()
    {
        ObservableCollection<string> weatherUpdates = new ObservableCollection<string>();
        weatherUpdates.CollectionChanged += (sender, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine($"Weather Update: {e.NewItems[0]}");
        };

        weatherUpdates.Add("New York: Sunny, 25°C");
        weatherUpdates.Add("London: Rainy, 15°C");
        // Output:
        // Weather Update: New York: Sunny, 25°C
        // Weather Update: London: Rainy, 15°C
        Console.ReadKey();
    }
}
