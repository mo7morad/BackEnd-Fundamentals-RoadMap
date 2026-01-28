/*
Real-Time Stock Prices
Problem: Display a list of real-time stock prices that update dynamically.
*/


using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main()
    {
        ObservableCollection<string> stockPrices = new ObservableCollection<string>();
        stockPrices.CollectionChanged += (sender, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine($"New Stock Price Added: {e.NewItems[0]}");
        };

        stockPrices.Add("AAPL: 150.00");
        stockPrices.Add("MSFT: 240.50");
        // Output:
        // New Stock Price Added: AAPL: 150.00
        // New Stock Price Added: MSFT: 240.50
        Console.ReadKey();
    }
}