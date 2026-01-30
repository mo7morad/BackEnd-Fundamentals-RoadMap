/*
Traffic Light Simulation
Task: Use a BitArray to represent the state of traffic lights 
at 3 intersections (Red, Yellow, Green). Change the light for one intersection.
*/


/*
Traffic Light Simulation
Task: Use a BitArray to represent the state of traffic lights 
at 3 intersections (Red, Yellow, Green).
*/

using System;
using System.Collections;

// Enum makes code readable: No more magic numbers (0, 1, 2)
enum TrafficLight
{
    Red = 0,
    Yellow = 1,
    Green = 2
}

class Program
{
    static void Main()
    {
        // 1. We need 9 bits total: 3 Intersections * 3 Lights each
        BitArray trafficSystem = new BitArray(9);

        // 2. Initialize: Set all intersections to RED initially
        SetTrafficLight(trafficSystem, 0, TrafficLight.Red); // Intersection 1
        SetTrafficLight(trafficSystem, 1, TrafficLight.Red); // Intersection 2
        SetTrafficLight(trafficSystem, 2, TrafficLight.Red); // Intersection 3

        Console.WriteLine("--- Initial State ---");
        PrintSystemState(trafficSystem);

        // 3. Task: Change Intersection 2 to GREEN
        Console.WriteLine("\n🚦 Light Change: Intersection 2 -> GREEN 🚦\n");
        SetTrafficLight(trafficSystem, 1, TrafficLight.Green);

        Console.WriteLine("--- Updated State ---");
        PrintSystemState(trafficSystem);
        
        Console.ReadKey();
    }

    static void SetTrafficLight(BitArray bits, int intersectionIndex, TrafficLight color)
    {
        // Calculate the starting bit index for this intersection
        // Intersection 0 starts at 0, Intersection 1 starts at 3, etc.
        int baseIndex = intersectionIndex * 3;

        // Step A: Turn OFF all lights for this intersection first
        // (Because a traffic light can't be Red AND Green at the same time)
        bits[baseIndex + 0] = false; // Red Off
        bits[baseIndex + 1] = false; // Yellow Off
        bits[baseIndex + 2] = false; // Green Off

        // Step B: Turn ON the requested light
        // We add the enum value (0, 1, or 2) to the base index
        bits[baseIndex + (int)color] = true;
    }

    // Helper to visualize the BitArray
    static void PrintSystemState(BitArray bits)
    {
        for (int i = 0; i < 3; i++)
        {
            int baseIndex = i * 3;
            // Check which bit is on
            string status = "";
            if (bits[baseIndex + 0]) status = "[RED]";
            else if (bits[baseIndex + 1]) status = "[YELLOW]";
            else if (bits[baseIndex + 2]) status = "[GREEN]";
            
            Console.WriteLine($"Intersection {i + 1}: {status}");
        }
    }
}



// using System;
// using System.Collections;

// class Program
// {
//     static void Main()
//     {
//         BitArray trafficLights = new BitArray(9); // 3 intersections, 3 lights each
//         // Green at intersection 1
//         trafficLights[2] = true;

//         // Change light to Yellow
//         trafficLights[2] = false;
//         trafficLights[1] = true;

//         Console.WriteLine("Intersection 1 Lights:");
//         Console.WriteLine($"Red: {trafficLights[0]}, Yellow: {trafficLights[1]}, Green: {trafficLights[2]}");
//         Console.ReadKey();
//     }
// }
