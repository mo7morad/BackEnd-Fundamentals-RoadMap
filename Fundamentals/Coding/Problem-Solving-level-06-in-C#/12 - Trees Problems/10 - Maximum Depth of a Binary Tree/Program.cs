/*
Maximum Depth of a Binary Tree
Calculate the maximum depth (or height) of a binary tree.
*/

using System;

class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }


    public TreeNode(int value)
    {
        Value = value;
    }
}

class BinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;


        // Recursively calculate depth of left and right subtrees
        int leftDepth = MaxDepth(root.Left);
        int rightDepth = MaxDepth(root.Right);


        // Return the larger depth + 1 (for the current level)
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}


class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();


        // Build a sample tree
        var root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);


        // Calculate and print the maximum depth
        Console.WriteLine($"Maximum Depth: {tree.MaxDepth(root)}");


        // Pause the screen
        Console.ReadKey();
    }
}
