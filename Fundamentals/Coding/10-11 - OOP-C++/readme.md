# Courses 10 & 11: Object-Oriented Programming (OOP) in C++

This directory contains the complete source code, libraries, and capstone projects for **Course 11** of the Backend Engineering Roadmap.

This phase represents the most significant shift in my engineering journey: transitioning from **Procedural Programming** (functions and logic) to **Object-Oriented Architecture** (systems and entities). Here, I mastered the art of modeling real-world problems using Classes, Objects, and Design Patterns.

## 📂 Directory Structure
**Please Do Not Hesitate, to open and see the Detailed readme for each Project, and folder.**

The content is organized into two main categories:

### 1. 📘 [Concepts](./Concepts)
This folder contains the foundational building blocks and exercises used to master OOP theory. It includes:
* **Core Libraries:** The source code for my custom `clsString`, `clsDate`, and `clsInputValidate` libraries.
* **OOP Exercises:** Standalone files demonstrating specific concepts like:
    * **Inheritance:** `clsPerson.h` vs `clsEmployee.h`.
    * **Polymorphism:** Abstract base classes and virtual functions.
    * **Templates:** Generic programming examples.
* **Header Management:** A clean `headers/` directory structure showing how to organize dependencies professionally.

### 2. 🚀 [Projects](./Projects)
This folder contains three massive Capstone Projects that apply the concepts in real-world scenarios. Each project lives in its own subdirectory with a fully layered architecture.

#### 📇 [Project 1: Contact Management System](./Projects/ContactsSystem-Project)
A Data-Driven Application focusing on **CRUD operations**.
* **Focus:** File I/O, Data Parsing, and Search Algorithms.
* **Architecture:** Separated the "Screen" logic from the "Contact" business object.

#### 🏎️ [Project 2: Driving Simulation](./Projects/DrivingSimulation-Project)
A Logic-Driven Application focusing on **Object Interaction**.
* **Focus:** State Management, Simulation Loops, and Physics calculations.
* **Highlights:** Changing object properties (Wheels/Engine) dynamically at runtime.

#### 🏦 [Project 3: Enterprise Banking System](./Projects/OOP-BankingSystem-Project)
The Ultimate Capstone. A complete re-write of the Bank project using OOP.
* **Focus:** Enterprise Architecture, Security, and Scalability.
* **Features:** Multi-User Permissions, Currency Exchange Module, Transfer Logging, and Login Auditing.
* 
---

## 🧠 Key Topics Mastered

| Concept | Description |
| :--- | :--- |
| **Encapsulation** | Protecting data integrity using Access Specifiers (`private`, `public`, `protected`). |
| **Abstraction** | Hiding complex implementation details behind clean Interfaces (Abstract Classes). |
| **Inheritance** | Creating specialized classes (`Employee`) from generalized ones (`Person`) to maximize code reuse. |
| **Polymorphism** | Using Virtual Functions to allow objects to behave differently depending on their specific type. |
| **Templates** | Writing generic, type-safe code (e.g., `clsInputValidate<int>` vs `clsInputValidate<double>`). |

## 🛠️ How to Navigate
1.  Start with the **Concepts** folder to see the raw implementation of my libraries (`String`, `Date`).
2.  Move to **Contact Management System** to see how these libraries are used in a simple application.
3.  Finish with **Enterprise Banking System** to see a full-scale Enterprise architecture.

---
*This repository documents my journey in mastering Backend Engineering.*
