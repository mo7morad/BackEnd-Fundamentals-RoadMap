/*
Directory Size Calculation
You need to calculate the total size of a directory, including all its files and subdirectories.
*/

using System;
using System.Collections.Generic;

class DirectoryNode
{
    public string Name { get; set; } // Directory or file name
    public int Size { get; set; } // File size (0 for directories)
    public List<DirectoryNode> Children { get; set; } = new List<DirectoryNode>(); // Subdirectories or files


    public DirectoryNode(string name, int size)
    {
        Name = name;
        Size = size;
    }


    // Recursive method to calculate the total size of the directory
    public int CalculateTotalSize()
    {
        int totalSize = Size; // Start with the current node's size
        foreach (var child in Children)
        {
            totalSize += child.CalculateTotalSize(); // Add sizes of all child nodes
        }
        return totalSize;
    }


    public void Print(string indent = "")
    {
        Console.WriteLine($"{indent}{Name} (Size: {Size})");
        foreach (var child in Children)
        {
            child.Print(indent + "  ");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Create directory structure
        var root = new DirectoryNode("root", 0);
        var documents = new DirectoryNode("Documents", 0);
        var photos = new DirectoryNode("Photos", 0);


        documents.Children.Add(new DirectoryNode("Resume.docx", 50));
        documents.Children.Add(new DirectoryNode("Project.pdf", 100));


        photos.Children.Add(new DirectoryNode("Vacation.jpg", 200));


        root.Children.Add(documents);
        root.Children.Add(photos);


        // Print directory structure
        Console.WriteLine("Directory Structure:");
        root.Print();


        // Calculate and display total size
        Console.WriteLine($"\nTotal size of the directory: {root.CalculateTotalSize()} bytes");


        // Pause the screen
        Console.ReadKey();
    }
}