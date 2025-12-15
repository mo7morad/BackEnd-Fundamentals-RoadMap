# Course 10: C++ Object-Oriented Programming (OOP)

This directory contains my solutions, class designs, and library implementations for **Course 10** of the Backend Engineering Roadmap.

In this course, I shifted my programming paradigm from Procedural Programming to **Object-Oriented Programming (OOP)**. I learned how to model real-world problems using **Classes and Objects**, focusing on the four pillars of OOP: **Encapsulation, Abstraction, Inheritance, and Polymorphism**.

## 🏆 Capstone Libraries

Instead of simple exercises, I rebuilt my previous functional libraries into robust, reusable **Classes**.

### 1. 📅 Date Class (`clsDate.h`)
A massive upgrade from my previous functional Date library.
* **Encapsulation:** All logic (Days, Months, Years) is hidden behind a clean interface.
* **Constructors:** Supports multiple ways to create a date:
    * `clsDate()`: Current System Date.
    * `clsDate("31/1/2022")`: Parse from String.
    * `clsDate(1, 1, 2022)`: From Day, Month, Year.
    * `clsDate(DayOrder, Year)`: From the day number in the year (e.g., 250th day).
* **Static vs. Dynamic:** Implemented utility functions (like `IsLeapYear`) as **Static Methods** so they can be called without creating an object.

### 2. 📝 String Class (`clsString.h`)
A wrapper class around the standard `std::string` providing 20+ advanced manipulation methods.
* **Methods:** `CountWords`, `UpperFirstLetter`, `InvertCase`, `Split`, `Trim`, and `Join`.
* **Flexibility:** Methods can be called on the object itself (`S1.Trim()`) or as static utilities (`clsString::Trim(S1)`).

### 3. 👥 Person & Employee System (`clsPerson.h`, `clsEmployee.h`)
A classic demonstration of **Inheritance**.
* **Base Class (`clsPerson`):** Handles generic attributes like ID, Name, Email, and Phone.
* **Derived Class (`clsEmployee`):** Inherits from Person and extends it with Title, Department, and Salary.
* **Interface:** `SendEmail()` and `SendSMS()` methods simulate communication behaviors.

---

## 📂 Topics Covered

The code files demonstrate mastery of the following OOP concepts:

### 1. 🏗️ Class Architecture
* **Classes vs Objects:** Understanding the blueprint vs the instance.
* **Access Specifiers:** Protecting data using `private`, `protected`, and `public`.
* **Properties:** Implementing **Getters and Setters** to control access to private members (e.g., `setSalary`, `Title()`).

### 2. 🔄 Object Lifecycle
* **Constructors:** Default, Parameterized, and Copy Constructors to initialize objects safely.
* **Destructors:** Managing resource cleanup when an object goes out of scope.

### 3. 🧬 Inheritance & Polymorphism
* **Inheritance:** Creating new classes based on existing ones to reuse code (`clsEmployee` inherits `clsPerson`).
* **Overriding:** Redefining base class methods in the derived class.
* **Virtual Functions:** Enabling **Polymorphism** and Dynamic Binding.
* **Abstract Classes:** Creating Interfaces using **Pure Virtual Functions**.

### 4. 🛠️ Advanced Concepts
* **Static Members:** Variables shared across all instances of a class.
* **Friend Classes:** Granting special access to private members for helper classes.
* **The `this` Pointer:** Understanding current object context.
* **Objects in Memory:** Passing objects by Value vs. by Reference.

## 🛠️ Tech Stack
* **Language:** C++
* **Paradigm:** Object-Oriented Programming (OOP)
* **Key Files:**
    * `clsDate.h`: The Date Class implementation.
    * `clsString.h`: The String Class implementation.
    * `clsPerson.h` / `clsEmployee.h`: Inheritance examples.
    * `Calculator.cpp`: A simple class-based calculator with an internal "History" state.

## 🚀 How to Run
To run the Employee system test:

1.  **Compile:**
    ```bash
    g++ Employee.cpp -o App
    ```
2.  **Run:**
    ```bash
    ./App
    ```

## 📝 Key Takeaways
* **Thinking in Objects:** I no longer see programs as a list of instructions, but as a system of interacting objects.
* **Code Security:** Using `private` attributes ensures that data cannot be corrupted from outside the class.
* **Reusability:** Inheritance allows me to write code once (`clsPerson`) and use it everywhere (`clsEmployee`, `clsClient`, `clsUser`).

---
*This repository documents my journey in mastering Backend Engineering.*
