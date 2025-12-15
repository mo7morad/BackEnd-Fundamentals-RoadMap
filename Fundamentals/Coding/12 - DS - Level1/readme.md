# Course 12: Data Structures Level 1

This directory contains my implementations of fundamental **Data Structures** in C++, created for **Course 12** of the Backend Engineering Roadmap.

In this phase, I moved beyond standard libraries to build core data structures from scratch. This was essential for understanding memory management, pointer manipulation, and the **Big O** efficiency of different operations (Insertion, Deletion, Search).

## 📂 Topics & Implementations

The code files demonstrate the manual construction of the following structures:

### 1. 🔗 [Singly Linked List (`linkedlist.cpp`)](./linkedlist.cpp)
A dynamic chain of nodes where each node points to the next.
* **Core Operations:** `InsertFirst`, `InsertLast`, `InsertAt`, and `Delete` specific values.
* **Search & Analysis:** Implemented `IsExists` to find values and `IndexOf` to return their position.
* **Efficiency:** Learned that insertion at the *head* is $O(1)$, while insertion at the *tail* (without a tail pointer) is $O(N)$.

### 2. ⛓️ [Doubly Linked List (`doublylinkedlist.cpp`)](./doublylinkedlist.cpp)
An advanced list where nodes have pointers to both **Next** and **Previous** nodes, allowing bidirectional traversal.
* **Optimization:** Implemented smart insertion logic (`_InsertAtUsingHEAD` vs `_InsertAtUsingREAR`) to traverse from the closest end, cutting traversal time in half.
* **Memory Management:** A custom destructor `~DoublyLinkedList()` ensures all nodes are properly deleted to prevent memory leaks.
* **Flexibility:** Supports full CRUD operations including deleting the Head, Tail, or Middle nodes safely.

### 3. 📦 [Dynamic Array (`array.cpp`)](./array.cpp)
A custom Array ADT (Abstract Data Type) that overcomes the fixed-size limitation of standard arrays.
* **Dynamic Resizing:** The `Enlarge()` method allocates a new, larger block of memory and migrates existing data automatically.
* **Data Manipulation:** Supports `Append`, `Insert` (shifting elements right), and `Delete` (shifting elements left).
* **Merging:** Logic to combine two separate arrays into a single larger one.

### 4. 🗺️ [HashMap / Dictionary (`Map Example.cpp`)](./Map%20Example.cpp)
Introduction to Key-Value pair storage using the standard `std::map`.
* **Usage:** Storing Student Names (Key) and Grades (Value) for fast lookup.
* **Search:** Efficiently checking for keys using `.find()` to avoid errors when accessing non-existent data.

## 🛠️ Tech Stack
* **Language:** C++
* **Concepts:**
    * **Templates (`template <class T>`):** Used to make the Linked List classes generic (working with `int`, `string`, etc.).
    * **Pointers:** Heavy use of raw pointers (`Node* next`, `Node* prev`) for manual memory linking.
    * **Memory Management:** Manual `new` and `delete` operations.

## 🚀 How to Run

To test the Doubly Linked List implementation:

1.  **Compile:**
    ```bash
    g++ doublylinkedlist.cpp -o DLLApp
    ```
2.  **Run:**
    ```bash
    ./DLLApp
    ```

## 📝 Key Takeaways
* **Memory Anatomy:** I now visualize data not just as variables, but as blocks of memory linked by addresses.
* **Trade-offs:** Learned why an **Array** is better for access ($O(1)$) but a **Linked List** is better for insertion/deletion ($O(1)$ at known positions).
* **Generic Programming:** Mastering C++ Templates allowed me to write a single Data Structure class that works for any data type.

---
*This repository documents my journey in mastering Backend Engineering.*
