/*
Light Control System
Task: Represent the state of lights in a smart home system with 8 lights.
Update the status of specific lights and turn all lights off at once.
*/

using System;
using System.Collections;

class Program
{
    static void Main()
    {
        BitArray lights = new BitArray(8, false); // All lights off
        lights[0] = true; // Turn on Light 1
        lights[5] = true; // Turn on Light 6

      Console.WriteLine($"Light 1: {lights[0]}, Light 6: {lights[5]}"); // Output: Light 1: True, Light 6: True

        lights.SetAll(false); // Turn off all lights
        Console.WriteLine($"Light 1 after reset: {lights[0]}"); // Output: Light 1 after reset: False
        Console.ReadKey();
    }
}