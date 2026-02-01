/*
Representing a Social Network
Create a system to represent a social network where each person has connections (friends).
The structure should allow traversal and printing of a person's connections.

Note: User Tree.

Output:

Alice's Social Network:

Alice
  Bob
  Charlie
*/

using System;
using System.Collections.Generic;


class Person
{
    public string Name { get; set; } // Name of the person
    public List<Person> Friends { get; set; } = new List<Person>(); // List of friends (connections)


    // Constructor to initialize a person with a name
    public Person(string name)
    {
        Name = name;
    }


    // Recursive method to print the person's social network up to a specified depth
    public void PrintFriends(int depth, string indent = "")
    {
        if (depth == 0) return; // Stop printing if the depth limit is reached
        Console.WriteLine(indent + Name); // Print the current person's name
        foreach (var friend in Friends) // Loop through the list of friends
        {
            friend.PrintFriends(depth - 1, indent + "  "); // Recursively print friends with reduced depth
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Create instances of people
        var alice = new Person("Alice");
        var bob = new Person("Bob");
        var charlie = new Person("Charlie");
        var dave = new Person("Dave");


        // Establish friendships
        alice.Friends.Add(bob); // Alice is friends with Bob
        alice.Friends.Add(charlie); // Alice is friends with Charlie
        bob.Friends.Add(dave); // Bob is friends with Dave


        // Print Alice's social network up to 2 levels deep
        Console.WriteLine("Alice's Social Network:");
        alice.PrintFriends(2); // Print friends and friends-of-friends


        // Pause the screen
        Console.ReadKey();
    }
}
