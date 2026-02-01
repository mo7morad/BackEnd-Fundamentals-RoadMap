/*

Hierarchical Employee Management
Design a system to represent a company's hierarchy, where each employee has a position and may manage other employees. The structure should allow the entire hierarchy to be printed.

Output:

Company Hierarchy:

CEO: Alice
  VP of Marketing: Bob
Marketing Manager: Charlie
  VP of Technology: Lara
  Architect: Tom
*/

using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public List<Employee> Subordinates { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
        Subordinates = new List<Employee>();
    }

    public void AddSubordinate(Employee emp)
    {
        Subordinates.Add(emp);
    }
}

class Program
{
    static void Main()
    {
        // Build the Hierarchy (CEO is the Root)
        Employee ceo = new Employee("Alice", "CEO");

        // Marketing Branch
        Employee vpMarketing = new Employee("Bob", "VP of Marketing");
        Employee mktManager = new Employee("Charlie", "Marketing Manager");
        
        vpMarketing.AddSubordinate(mktManager); // Bob manages Charlie

        // Technology Branch
        Employee vpTech = new Employee("Lara", "VP of Technology");
        Employee architect = new Employee("Tom", "Architect");
        
        vpTech.AddSubordinate(architect); // Lara manages Tom

        // Build the full tree
        ceo.AddSubordinate(vpMarketing);
        ceo.AddSubordinate(vpTech);

        // Print
        Console.WriteLine("Company Hierarchy:");
        PrintHierarchy(ceo, 0);

        Console.ReadKey();
    }

    static void PrintHierarchy(Employee emp, int indentLevel)
    {
        string indent = new string(' ', indentLevel * 2);
        
        Console.WriteLine($"{indent}{emp.Position}: {emp.Name}");

        foreach (var subordinate in emp.Subordinates)
        {
            PrintHierarchy(subordinate, indentLevel + 1);
        }
    }
}