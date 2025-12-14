# Course: C# Functional Programming & LINQ

This directory contains my deep dive into **Functional Programming** concepts in C# and the **LINQ (Language Integrated Query)** architecture.

In this phase, I refactored my coding mindset. I learned to replace verbose `foreach` loops with concise, readable, and expressive LINQ queries. I mastered the underlying mechanisms of LINQ—Delegates, Extension Methods, and the `IEnumerable<T>` interface—to write cleaner and more maintainable code.

## 📂 Topics Covered

The course is structured to build the LINQ engine from the ground up before using it.

### 1. 🏗️ The Foundations (Functional C#)
Understanding the building blocks that make LINQ possible.
* **Delegates:** Using `Func<T, TResult>`, `Action<T>`, and `Predicate<T>` to pass functions as variables.
* **Lambda Expressions:** Writing anonymous functions using the concise `=>` syntax.
* **Extension Methods:** How to "add" methods to existing types (like adding `.Filter()` to `List<T>`) without modifying the source code.
* **Anonymous Types:** Creating temporary data structures (`new { Name = "Ali", Age = 20 }`) on the fly.

### 2. ⚙️ LINQ Architecture
* **`IEnumerable<T>` & `IEnumerator`:** The standard mechanism for iterating over collections.
* **Yield Return:** Creating stateful iterators using the `yield` keyword.
* **Deferred vs. Immediate Execution:** Understanding why a query doesn't run until you loop over it (Deferred) vs. creating a list immediately (`.ToList()`).

### 3. 🔍 LINQ Operators (The Toolkit)
I mastered the standard query operators for manipulating data collections:
* **Filtering:** `Where()`, `OfType<T>()`.
* **Projection:** `Select()` (Transformation), `SelectMany()` (Flattening lists of lists).
* **Sorting:** `OrderBy()`, `OrderByDescending()`, `ThenBy()`.
* **Grouping:** `GroupBy()` to categorize data (e.g., Group Students by Class).
* **Set Operations:** `Distinct()`, `Union()`, `Intersect()`, `Except()`.
* **Quantifiers:** `Any()`, `All()`, `Contains()`.
* **Aggregation:** `Count()`, `Sum()`, `Min()`, `Max()`, `Average()`, `Aggregate()`.
* **Partitioning:** `Take()`, `Skip()`, `TakeWhile()`, `SkipWhile()` (Pagination logic).
* **Element Operators:** `First()`, `FirstOrDefault()`, `Single()`, `Last()`.

### 4. 📝 Syntax Styles
* **Method Syntax (Fluent API):** Chaining methods (`list.Where(x => x > 5).Select(x => x * 2)`).
* **Query Syntax:** SQL-like structure (`from x in list where x > 5 select x * 2`).

---

## 🏆 Key Implementations & Examples

This repository contains varied data analysis examples demonstrating the power of LINQ.

### 1. 📊 Data Analysis System
A project analyzing complex lists of `Product` and `Customer` objects.
* **Scenario:** "Find top 5 most expensive products that are currently in stock."
* **Code:**
    ```csharp
    var topProducts = products
        .Where(p => p.Stock > 0)
        .OrderByDescending(p => p.Price)
        .Take(5)
        .Select(p => new { p.Name, p.Price }); // Projection to Anonymous Type
    ```

### 2. 🔄 Dynamic Filtering Engine
Using functional patterns to build filters dynamically.
* **Scenario:** Filtering a user list based on multiple optional criteria (Age, Country, ActiveStatus) without writing nested `if` statements.

### 3. 🧬 Set Operations
Comparison logic between two data sources.
* **Scenario:** Finding "New Customers" by comparing today's customer list with yesterday's list using `Except()`.

## 🛠️ Tech Stack
* **Language:** C#
* **Core Concepts:** Functional Programming, Immutability, Pure Functions, Deferred Execution.
* **Libraries:** `System.Linq`.

## 🚀 How to Run
These are Console Applications designed to demonstrate logic and output analysis results.

1.  Navigate to the specific folder (e.g., `Linq_Examples`).
2.  Run the project:
    ```bash
    dotnet run
    ```

---
*This repository documents my journey in mastering Backend Engineering.*
