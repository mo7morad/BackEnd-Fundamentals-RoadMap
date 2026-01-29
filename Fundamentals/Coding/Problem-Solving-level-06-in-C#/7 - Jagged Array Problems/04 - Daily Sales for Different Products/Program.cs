/*
Daily Sales for Different Products
Problem: Store the sales for different products, where each product has varying daily sales.
*/

using System;

class Program
{
    static void Main()
    {
        int[][] productSales = new int[3][];
        productSales[0] = new int[] { 100, 200, 150 }; // Product 1
        productSales[1] = new int[] { 300, 400 };      // Product 2
        productSales[2] = new int[] { 500, 600, 550, 700 }; // Product 3


        Console.WriteLine("Sales Data:");
        for (int i = 0; i < productSales.Length; i++)
        {
            Console.Write($"Product {i + 1}: ");
            Console.WriteLine(string.Join(", ", productSales[i]));
        }
        Console.ReadKey();
    }
}
// Output:
// Product 1: 100 200 150
// Product 2: 300 400
// Product 3: 500 600 550 700