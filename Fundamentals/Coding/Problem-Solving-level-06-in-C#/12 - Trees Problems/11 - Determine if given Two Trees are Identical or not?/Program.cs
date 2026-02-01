using System;

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
    // Method to determine if two trees are identical
    public bool AreIdentical(TreeNode root1, TreeNode root2)
    {
        // Base case: both nodes are null
        if (root1 == null && root2 == null) return true;


        // If one is null and the other is not, they are not identical
        if (root1 == null || root2 == null) return false;


        // Check if the current nodes are identical and recursively check subtrees
        return root1.Value == root2.Value
            && AreIdentical(root1.Left, root2.Left)
            && AreIdentical(root1.Right, root2.Right);
    }


    // Method to print a tree (in-order traversal)
    public void PrintTree(TreeNode root, string indent = "")
    {
        if (root == null) return;


        PrintTree(root.Left, indent + "  "); // Traverse the left subtree
        Console.WriteLine($"{indent}{root.Value}"); // Print the current node with indentation
        PrintTree(root.Right, indent + "  "); // Traverse the right subtree
    }
}


class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();


        // Create first tree
        var root1 = new TreeNode(1);
        root1.Left = new TreeNode(2);
        root1.Right = new TreeNode(3);
        root1.Left.Left = new TreeNode(4);
        root1.Left.Right = new TreeNode(5);


        // Create second tree (identical to the first tree)
        var root2 = new TreeNode(1);
        root2.Left = new TreeNode(2);
        root2.Right = new TreeNode(3);
        root2.Left.Left = new TreeNode(4);
        root2.Left.Right = new TreeNode(5);


        // Print both trees
        Console.WriteLine("Tree 1:");
        tree.PrintTree(root1);


        Console.WriteLine("\nTree 2:");
        tree.PrintTree(root2);


        // Check if the two trees are identical
        Console.WriteLine("\nAre the two trees identical?");
        Console.WriteLine(tree.AreIdentical(root1, root2)
            ? "Yes, the trees are identical."
            : "No, the trees are not identical.");


        // Create a third tree (not identical)
        var root3 = new TreeNode(1);
        root3.Left = new TreeNode(2);
        root3.Right = new TreeNode(4);


        Console.WriteLine("\nTree 3:");
        tree.PrintTree(root3);


        // Check if the first and third trees are identical
        Console.WriteLine("\nAre Tree 1 and Tree 3 identical?");
        Console.WriteLine(tree.AreIdentical(root1, root3)
            ? "Yes, the trees are identical."
            : "No, the trees are not identical.");


        // Pause the screen
        Console.ReadKey();
    }
}


