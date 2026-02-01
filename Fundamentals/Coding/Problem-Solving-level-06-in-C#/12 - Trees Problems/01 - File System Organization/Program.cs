/*
File System Organization
You need to design a system to represent a hierarchical file system where directories can contain files or other directories. 
The system should be able to display the structure in a readable format.

Output:

File System:

Directory: root

Directory: Documents
  File: Resume.docx
  File: Project.pdf

Directory: Photos
  File: Vacation.jpg
  File: Diving.jpg
  File: Family.jpg
*/



using System;
using System.Collections.Generic;

namespace FileSystemApp
{
    class FileSystemNode
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
        public List<FileSystemNode> Children { get; set; }

        public FileSystemNode(string name, bool isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;
            Children = new List<FileSystemNode>();
        }

        public void Add(FileSystemNode node)
        {
            if (IsDirectory)
            {
                Children.Add(node);
            }
            else
            {
                Console.WriteLine($"Error: Cannot add '{node.Name}' to file '{Name}'. Only directories can have children.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            FileSystemNode root = new FileSystemNode("root", true);

            // Folder: Documents
            FileSystemNode docs = new FileSystemNode("Documents", true);
            docs.Add(new FileSystemNode("Resume.docx", false));
            docs.Add(new FileSystemNode("Project.pdf", false));

            // Folder: Photos
            FileSystemNode photos = new FileSystemNode("Photos", true);
            photos.Add(new FileSystemNode("Vacation.jpg", false));
            photos.Add(new FileSystemNode("Diving.jpg", false));
            photos.Add(new FileSystemNode("Family.jpg", false));

            // Attach folders to root
            root.Add(docs);
            root.Add(photos);

            // 3. Print (The Output)
            Console.WriteLine("File System Structure:");
            PrintTree(root, 0);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void PrintTree(FileSystemNode node, int indentLevel)
        {
            // A. Indentation Logic: Create spaces based on depth
            string indent = new string(' ', indentLevel * 2);
            
            // Visual sugar to distinguish files/folders
            string icon = node.IsDirectory ? "📂" : "📄"; 

            // B. Print the current node (The Parent)
            Console.WriteLine($"{indent}{icon} {node.Name}");

            // C. Recursive Step: Visit all children
            foreach (var child in node.Children)
            {
                // Go deeper! Increase indent level by 1
                PrintTree(child, indentLevel + 1);
            }
        }
    }
}