/*
City Temperature Data
Problem: Store daily temperature readings for multiple cities,
where each city has a different number of recorded days.
*/


using System;
class Program
{
    static void Main()
    {
        double[][] cityTemperatures = new double[2][];
        cityTemperatures[0] = new double[] { 29.5, 30.0, 28.7 }; // City 1
        cityTemperatures[1] = new double[] { 25.0, 26.5 };       // City 2


        Console.WriteLine("Temperature Data:");
        for (int i = 0; i < cityTemperatures.Length; i++)
        {
            Console.Write($"City {i + 1}: ");
            foreach (double temp in cityTemperatures[i])
            {
                Console.Write(temp + "°C ");
            }
            Console.WriteLine();
        }
        // Output:
        // City 1: 29.5°C 30°C 28.7°C
        // City 2: 25°C 26.5°C    }
  }
}