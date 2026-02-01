using System;
using System.Collections.Generic;


class TreeNode
{
    public int Value { get; set; } // Value of the node
    public TreeNode Left { get; set; } // Left child
    public TreeNode Right { get; set; } // Right child


    public TreeNode(int value)
    {
        Value = value; // Initialize the node with a value
    }
}


class BinaryTree
{
    // Method to print the tree (in-order traversal)
    public void PrintTree(TreeNode root, string indent = "")
    {
        if (root == null) return;


        PrintTree(root.Left, indent + "  "); // Traverse the left subtree
        Console.WriteLine($"{indent}{root.Value}"); // Print the current node with indentation
        PrintTree(root.Right, indent + "  "); // Traverse the right subtree
    }


    // Method to find the largest value at each level
    public List<int> LargestValuesAtEachLevel(TreeNode root)
    {
        var result = new List<int>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);


        // Perform level-order traversal
        while (queue.Count > 0)
        {
            int levelSize = queue.Count; // Number of nodes at the current level
            int maxValue = int.MinValue;


            // Process all nodes at the current level
            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                maxValue = Math.Max(maxValue, node.Value); // Update max value for this level


                // Enqueue left and right children
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }

            result.Add(maxValue); // Add the largest value for this level to the result
        }


        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();


        // Create a sample tree
        var root = new TreeNode(1);
        root.Left = new TreeNode(3);
        root.Right = new TreeNode(2);
        root.Left.Left = new TreeNode(5);
        root.Left.Right = new TreeNode(3);
        root.Right.Right = new TreeNode(9);


        // Print the tree
        Console.WriteLine("Binary Tree:");
        tree.PrintTree(root);


        // Find and print the largest value at each level
        Console.WriteLine("\nLargest Values at Each Level:");
        var largestValues = tree.LargestValuesAtEachLevel(root);
        for (int i = 0; i < largestValues.Count; i++)
        {
            Console.WriteLine($"Level {i + 1}: {largestValues[i]}");
        }


        // Pause the screen
        Console.ReadKey();
    }
}

