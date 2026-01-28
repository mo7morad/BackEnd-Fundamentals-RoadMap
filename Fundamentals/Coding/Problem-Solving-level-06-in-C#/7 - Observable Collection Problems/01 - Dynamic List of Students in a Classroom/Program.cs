/*

Dynamic List of Students in a Classroom
Problem: Maintain and display a dynamic list of students in a classroom.

Example: Add, remove, or replace students in real-time, and notify changes to event;
so you can use it to change UI.
*/

using System;
using System.Collections.Generic;

public class StudentChangeEventArgs : EventArgs
{
    public string Action { get; } // "Added", "Removed", "Replaced"
    public string StudentName { get; }

    public StudentChangeEventArgs(string action, string name)
    {
        Action = action;
        StudentName = name;
    }
}

// Using Composition 
public class ObservableStudentList
{
    private List<string> _students = new List<string>();
    public event EventHandler<StudentChangeEventArgs> OnListChanged;

    // --- Wrapper Methods ---

    public void AddStudent(string name)
    {
        _students.Add(name);
        Notify("Added", name);
    }

    public void RemoveStudent(string name)
    {
        if (_students.Contains(name))
        {
            _students.Remove(name);
            Notify("Removed", name);
        }
    }

    public void ReplaceStudent(string oldName, string newName)
    {
        int index = _students.IndexOf(oldName);
        if (index != -1)
        {
            _students[index] = newName;
            Notify("Replaced", $"{oldName} with {newName}");
        }
    }

    public void PrintAll()
    {
        Console.WriteLine($"[Current Class]: {string.Join(", ", _students)}");
    }

    private void Notify(string action, string name)
    {
        OnListChanged?.Invoke(this, new StudentChangeEventArgs(action, name));
    }
}

class Program
{
    static void Main()
    {
        var classroom = new ObservableStudentList();

        // Subscribe to changes
        classroom.OnListChanged += (sender, e) => 
        {
            Console.WriteLine($"📢 UI ALERT: Student {e.StudentName} was {e.Action}.");
        };

        classroom.AddStudent("Mohamed");
        classroom.AddStudent("Ali");     
        
        classroom.PrintAll();

        classroom.ReplaceStudent("Ali", "Omar");
        classroom.RemoveStudent("Mohamed");

        classroom.PrintAll();
    }
}


// Course Solution

// using System;
// using System.Collections.ObjectModel;
// using System.Collections.Specialized;

// class Program
// {
//     static void Main()
//     {
//         ObservableCollection<string> students = new ObservableCollection<string>();
       
//         students.CollectionChanged += (sender, e) =>
//         {
//            //this event will be fired on any change (add or remove.

//             if (e.Action == NotifyCollectionChangedAction.Add)
//                 Console.WriteLine($"New Student Added: {e.NewItems[0]}");
//             if (e.Action == NotifyCollectionChangedAction.Remove)
//                 Console.WriteLine($"Student Removed: {e.OldItems[0]}");

//         };

//         students.Add("Alice");
//         students.Add("Bob");
//         students.Remove("Alice");
//         // Output:
//         // New Student Added: Alice
//         // New Student Added: Bob
//         // Student Removed: Alice
//         Console.ReadKey();
//     }
// }