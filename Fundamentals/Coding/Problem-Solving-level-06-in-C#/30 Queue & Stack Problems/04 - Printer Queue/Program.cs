using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
      Queue<PrinterJob> printerQueue = new Queue<PrinterJob>();
      printerQueue.Enqueue(new PrinterJob("CV"));
      printerQueue.Enqueue(new PrinterJob("Passport"));
      printerQueue.Enqueue(new PrinterJob("eVisa"));
      printerQueue.Dequeue().UsePrinter(); // Output: Preparing CV
      printerQueue.Dequeue().UsePrinter(); // Output: Preparing Passport
      printerQueue.Dequeue().UsePrinter(); // Output: Preparing eVisa
    }

    public class PrinterJob
  {
    private string _item;

    public PrinterJob(string item)
    {
        _item = item;
    }
    private void PrepareItem()
    {
        Console.WriteLine("Preparing " + _item);
    }

    private void PrintItem()
    {
        Console.WriteLine("Printing " + _item);
    }

    public void UsePrinter()
    {
        PrepareItem();
        PrintItem();
    }
  }
}
