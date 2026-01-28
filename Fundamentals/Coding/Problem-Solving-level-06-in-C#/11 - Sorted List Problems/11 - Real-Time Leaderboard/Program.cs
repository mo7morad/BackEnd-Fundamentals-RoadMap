/*
Real-Time Leaderboard
Problem: Track players’ scores in a game, sorted by player names.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedList<string, int> leaderboard = new SortedList<string, int>
        {
            { "Alice", 1200 },
            { "Charlie", 1500 },
            { "Bob", 1300 }
        };

        foreach (var player in leaderboard)
        {
            Console.WriteLine($"Player: {player.Key}, Score: {player.Value}");
        }
        Console.ReadKey();

        // Output:
        // Player: Alice, Score: 1200
        // Player: Bob, Score: 1300
        // Player: Charlie, Score: 1500
    }
}

