# 🏛️ Backend Engineering Fundamentals

**The core coding curriculum of the Backend Engineering Roadmap.**

Welcome to the technical archive of my journey from C++ fundamentals to Enterprise Architecture. This directory contains the source code, logic, and design patterns for **Courses 08 through 26**, organized by technology stack and complexity.

---

## 🗺️ Quick Navigation Map

| Phase | Focus Area | Courses & Projects |
| :--- | :--- | :--- |
| **Phase 1** | **C++ & Algorithms** | [Algorithms](./Coding/08%20-%20Algorithms%20&%20Problem-Solving%20Level%204) • [OOP Core](./Coding/10%20-%20OOP%20Concepts) • [OOP Apps](./Coding/11%20-%20OOP%20Applications) • [Data Structures](./Coding/12%20-%20Data%20Structures%20Level%201) |
| **Phase 2** | **.NET & Desktop** | [C# WinForms](./Coding/14%20-%20C%23%20Level%201) • [Advanced C# OOP](./Coding/16%20-%20C%23%20OOP) • [C# Level 2](./Coding/20%20-%20C%23%20Level%202) • [C# DS](./Coding/22%20-%20Data%20Structures%20Level%202) |
| **Phase 3** | **Database Engineering** | [SQL Design](./Coding/15%20-%20Database%20Level%201) • [SQL Projects](./Coding/17%20-%20SQL%20Projects) • [T-SQL Programming](./Coding/21%20-%20T-SQL) |
| **Phase 4** | **System Architecture** | [DB Connectivity (ADO)](./Coding/18%20-%20DB%20Connectivity) • [Web APIs](./Coding/25%20-%20APIs) • [SOLID Principles](./Coding/26%20-%20SOLID) |
| **🏆 Capstone** | **The Masterpiece** | [**🚗 DVLD Enterprise System**](./Coding/19%20-%20Full%20Real%20Project/DVLD-Project) |

---

## 🚀 Phase 1: The Foundation (C++ & Memory)
*Building the mental model of how computers process data.*

### 📂 [08 - Algorithms Level 4](./Coding/08%20-%20Algorithms%20&%20Problem-Solving%20Level%204)
**Complex Logic & Temporal Math.**
* **Projects:** Custom `Date` Library (Date difference, overlaps, validation), String manipulation library.
* **Key Skills:** Pointer arithmetic, Edge-case handling.

### 📂 [10 & 11 - OOP Concepts & Applications](./Coding/11%20-%20OOP%20Applications)
**Object-Oriented Analysis & Design.**
* **Projects:**
    * **[Bank System 2.0](./Coding/11%20-%20OOP%20Applications/BankSystem):** Refactored from procedural to modular OOP.
    * **Driving Simulator:** Using Abstract Classes for vehicle behavior.
* **Key Skills:** Encapsulation, Inheritance, Polymorphism, Abstract Classes.

### 📂 [12 & 13 - Data Structures (Built from Scratch)](./Coding/12%20-%20Data%20Structures%20Level%201)
**Memory Management & Optimization.**
I didn't use `std::vector`; I built my own.
* **Implementations:** `DoublyLinkedList`, `DynamicArray`, `GenericStack`, `GenericQueue`.
* **Projects:** [Queue Management System](./Coding/13%20-%20Algorithms%20&%20Problem%20Solving%20Level%205) (Visual Bank Line Simulation).

---

## 💻 Phase 2: The .NET Transition (C# Ecosystem)
*Moving from console scripts to Event-Driven Applications.*

### 📂 [14 - C# & Windows Forms](./Coding/14%20-%20C%23%20Level%201)
**GUI & Event Logic.**
* **Projects:**
    * **[🍕 Pizza POS](./Coding/14%20-%20C%23%20Level%201/Projects/PizzaProject):** Real-time price calculation dashboard.
    * **[❌ Tic-Tac-Toe](./Coding/14%20-%20C%23%20Level%201/Projects/TicTacToeGame):** Custom GDI+ graphics and game state logic.

### 📂 [16 - C# Advanced OOP](./Coding/16%20-%20C%23%20OOP)
**Professional .NET Architecture.**
* **Topics:** Interfaces vs Abstract Classes, Properties, Memory Management (Stack vs Heap).
* **Projects:** Modular Calculator Architecture.

### 📂 [20 - C# Level 2 (Runtime Mastery)](./Coding/20%20-%20C%23%20Level%202)
**Asynchronous & Decoupled Code.**
* **Key Concepts:** Delegates, Events (Publisher/Subscriber), Multithreading, Reflection.
* **Projects:** Traffic Light Control, Logger System.

### 📂 [22 - Data Structures in C#](./Coding/22%20-%20Data%20Structures%20Level%202)
**Collections Framework.**
* **Topics:** `Dictionary`, `HashSet`, `LinkedList`, Trees & Graphs implementations in C#.

---

## 🗄️ Phase 3: Database Engineering (SQL Server)
*Data persistence, integrity, and programmability.*

### 📂 [15 & 17 - Database Design & Implementation](./Coding/17%20-%20SQL%20Projects)
**Normalization & Schema Design.**
* **Projects:** Designed and implemented schemas for:
    * 🏥 **Clinic System**
    * 📚 **Library System**
    * 🛒 **Online Store**
* **Skills:** ER Diagrams, 3NF Normalization, Complex Joins.

### 📂 [21 - Advanced T-SQL](./Coding/21%20-%20T-SQL)
**Server-Side Logic.**
* **Scripts:** Stored Procedures, Triggers (Audit Logs), Cursors, Window Functions (`ROW_NUMBER`, `RANK`).

---

## 🏗️ Phase 4: Architecture & Modern Backend
*Building scalable, maintainable distributed systems.*

### 📂 [18 - DB Connectivity (3-Tier Architecture)](./Coding/18%20-%20DB%20Connectivity)
**The Architecture Turning Point.**
* **Concept:** Separating UI (Presentation), Logic (BLL), and Database (DAL).
* **Project:** [Contacts Manager](./Coding/18%20-%20DB%20Connectivity/ContactsProject) (Full CRUD with ADO.NET).

### 📂 [25 - Web APIs (ASP.NET Core)](./Coding/25%20-%20APIs)
**RESTful Services.**
* **Projects:**
    * **Student API:** CRUD endpoints, DTO mapping, Status Codes.
    * **Win32 Interop:** Controlling OS features via API.

### 📂 [26 - SOLID Principles](./Coding/26%20-%20SOLID)
**Clean Architecture.**
* **Refactoring:** Transforming tightly coupled code into testable, modular components using Dependency Injection and ISP.

---

## 🏆 The Crown Jewel: DVLD Project

### 📂 [View the DVLD Capstone Repository](./Coding/19%20-%20Full%20Real%20Project/DVLD-Project)

**Course 19** culminated in the **Driving & Vehicle License Department** system.
* **30+ Screens:** A massive WinForms application.
* **Strict Architecture:** 3-Tier (PL -> BLL -> DAL).
* **Business Logic:** Complex rules for license issuance, testing order, and detainment.

---

## 🛠️ Tech Stack Profile

| Category | Technologies |
| :--- | :--- |
| **Languages** | C++, C# (.NET) |
| **Data** | SQL Server 2022, T-SQL, ADO.NET |
| **Frameworks** | Windows Forms, ASP.NET Core Web API |
| **Concepts** | OOP, SOLID, Design Patterns, Data Structures, Algorithms |
| **Tools** | Visual Studio 2022, SSMS, Git/GitHub, Swagger |

---
*Documenting the journey of becoming a World-Class Backend Engineer.*
