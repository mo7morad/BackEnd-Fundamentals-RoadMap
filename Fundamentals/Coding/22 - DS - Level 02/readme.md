# Course 22: Advanced Data Structures & Collections in C#

This directory contains my code examples, custom implementations, and performance comparisons for **Course 22** of the Backend Engineering Roadmap.

In this phase, I transitioned from manual data structure implementation (C++) to mastering the **.NET Collections Framework**. I learned to select the right tool for the job—understanding the trade-offs between `List`, `LinkedList`, `Dictionary`, and `HashSet`—and how to leverage **LINQ** for powerful data manipulation.

## 📂 Topics Covered

The course covers the full spectrum of C# data handling, from basic arrays to complex graph algorithms.

### 1. 📦 Standard Collections (Generics)
Replacing legacy collections with type-safe Generic collections.
* **`List<T>` vs `ArrayList`:** Understanding why `List<T>` is superior (no boxing/unboxing performance penalty).
* **`Dictionary<K,V>` vs `Hashtable`:** Mastering key-value lookups with $O(1)$ complexity.
* **`LinkedList<T>`:** Using the built-in doubly linked list for $O(1)$ insertions/deletions.
* **`Stack<T>` & `Queue<T>`:** Standard LIFO and FIFO implementations.

### 2. 🔢 Set Theory & Hashing
Handling unique data efficiently.
* **`HashSet<T>`:** High-performance unique collections.
* **Set Operations:** Implementing Mathematical Logic using C#:
    * **Union:** `UnionWith()`
    * **Intersection:** `IntersectWith()`
    * **Difference:** `ExceptWith()`
    * **Symmetric Difference:** `SymmetricExceptWith()`
* **Sorted Sets:** Using `SortedSet<T>` and `SortedList<K,V>` for auto-sorting data upon insertion.

### 3. 🌲 Non-Linear Data Structures
Since C# doesn't have built-in classes for these, I implemented them from scratch to understand the architecture:
* **Trees:**
    * **General Trees:** Nodes with $N$ children.
    * **Binary Trees:** Traversals (Pre-order, In-order, Post-order).
* **Heaps:**
    * **Min-Heap & Max-Heap:** Implementation for Priority Queues.
* **Graphs:**
    * **Representations:** Adjacency Matrix vs. Adjacency List.
    * **Traversals:** BFS (Breadth-First Search) and DFS (Depth-First Search).

### 4. 🧠 Advanced C# Features
* **Tuples:** Storing lightweight data groups without creating classes.
* **BitArray:** managing arrays of booleans compactly.
* **ObservableCollection:** Collections that notify the UI when items are added/removed (crucial for WPF/MAUI apps).
* **Jagged Arrays:** Creating arrays of arrays (matrices).

### 5. 🏗️ Collection Interfaces
Understanding the hierarchy that powers LINQ.
* **`IEnumerable<T>`:** The base interface that allows `foreach` loops.
* **`ICollection<T>`:** Adds `Add`, `Remove`, and `Count`.
* **`IList<T>`:** Adds indexer access `[i]`.
* **`IComparable`:** Implementing custom sorting logic for objects.

## 🏆 Key Implementations

This repository includes my custom C# implementations for structures not found in the standard library:

### 1. 🌳 Binary Tree
A fully functional Binary Tree class supporting:
* **Insertion:** Auto-balancing logic.
* **Traversal:** Methods to print tree contents in sorted order 3 types.

### 2. 🕸️ Graph System
A flexible Graph class supporting:
* **Vertex/Edge Management:** Adding nodes and connecting them.
* **Adjacency Logic:** Efficiently finding neighbors of a node.

## 🛠️ Tech Stack
* **Language:** C#
* **Framework:** .NET Core / .NET Framework
* **Concepts:** Generics, Boxing/Unboxing, Complexity Analysis (Big O).

---
*This repository documents my journey in mastering Backend Engineering.*
