/*
Binary Search Tree for Product Inventory
Use a Binary Search Tree (BST) to store product inventory where each product is identified by a unique ID.
The system should allow insertion, searching, and printing of products.
*/


using System;

class Product
{
    public int ID { get; set; } // Unique ID for the product
    public string Name { get; set; } // Name of the product


    public Product(int id, string name)
    {
        ID = id;
        Name = name;
    }


    public override string ToString()
    {
        return $"Product ID: {ID}, Name: {Name}";
    }
}


class BSTNode
{
    public Product Product { get; set; }
    public BSTNode Left { get; set; }
    public BSTNode Right { get; set; }


    public BSTNode(Product product)
    {
        Product = product;
    }
}


class BST
{
    private BSTNode root;


    // Insert a product into the BST
    public void Insert(Product product)
    {
        root = Insert(root, product);
    }


    private BSTNode Insert(BSTNode node, Product product)
    {
        if (node == null)
            return new BSTNode(product);


        if (product.ID < node.Product.ID)
            node.Left = Insert(node.Left, product);
        else if (product.ID > node.Product.ID)
            node.Right = Insert(node.Right, product);


        return node;
    }


    // Search for a product by ID
    public Product Search(int id)
    {
        return Search(root, id)?.Product;
    }


    private BSTNode Search(BSTNode node, int id)
    {
        if (node == null || node.Product.ID == id)
            return node;


        if (id < node.Product.ID)
            return Search(node.Left, id);


        return Search(node.Right, id);
    }


    // Print all products in sorted order
    public void PrintInOrder()
    {
        PrintInOrder(root);
    }


    private void PrintInOrder(BSTNode node)
    {
        if (node == null) return;


        PrintInOrder(node.Left);
        Console.WriteLine(node.Product);
        PrintInOrder(node.Right);
    }
}


class Program
{
    static void Main(string[] args)
    {
        var inventory = new BST();


        // Insert products
        inventory.Insert(new Product(101, "Laptop"));
        inventory.Insert(new Product(102, "Smartphone"));
        inventory.Insert(new Product(100, "Tablet"));


        // Search for a product
        var product = inventory.Search(102);
        Console.WriteLine(product != null ? $"Found: {product}" : "Product not found");


        // Print all products
        Console.WriteLine("\nProduct Inventory:");
        inventory.PrintInOrder();


        // Pause the screen
        Console.ReadKey();
    }
}

