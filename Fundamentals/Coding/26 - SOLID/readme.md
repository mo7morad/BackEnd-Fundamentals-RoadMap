# Course 26: SOLID Principles & Clean Architecture

This directory contains my refactoring exercises and architectural examples for **Course 26** of the Backend Engineering Roadmap.

In this phase, I focused on **Software Architecture**. I learned that writing code is easy, but writing code that survives change is hard. I mastered the **SOLID Principles** to build systems that are easy to maintain, test, and extend without breaking existing functionality.

## 📂 Topics & Principles

The course is structured around the five pillars of OOD (Object-Oriented Design), plus the Dependency Injection pattern.

### 1. 🟢 Single Responsibility Principle (SRP)
*"A class should have one, and only one, reason to change."*
* **The Problem:** A `UserService` class that handles User Logic AND Email Notification AND Error Logging.
* **The Solution:** Splitting this into `UserService`, `EmailService`, and `LoggerService`.
* **Projects:**
    * **Logging Service:** Refactored a monolithic logger into specific responsibilities.
    * **Notification Service:** Separated message formatting from the actual sending logic.

### 2. 🔵 Open/Closed Principle (OCP)
*"Software entities should be open for extension, but closed for modification."*
* **The Problem:** Modifying a `PaymentProcessor` class with `if/else` statements every time a new payment method (PayPal, Crypto) is added.
* **The Solution:** Using **Polymorphism** and **Abstract Classes**. I can now add a `CryptoPayment` class without touching the core processor code.
* **Projects:**
    * **Payment Service:** Implemented a plugin-style architecture where new payment types are added as new classes.

### 3. 🟡 Liskov Substitution Principle (LSP)
*"Subtypes must be substitutable for their base types."*
* **The Problem:** The classic "Ostrich" problem. If `Bird` has a `Fly()` method, and `Ostrich` inherits from `Bird` but throws an exception when `Fly()` is called, it violates LSP.
* **The Solution:** Segregating inheritance hierarchies based on behavior (e.g., `FlyingBird` vs. `FlightlessBird`) rather than just biological classification.
* **Projects:**
    * **Vehicle System:** Ensuring that derived classes (like `Bicycle`) don't break the contract of base classes (like `EngineVehicle`).

### 4. 🟣 Interface Segregation Principle (ISP)
*"Clients should not be forced to depend on methods they do not use."*
* **The Problem:** A "Fat Interface" like `IMultiFunctionDevice` that forces a simple Printer to implement `Scan()` and `Fax()`, throwing "Not Implemented" exceptions.
* **The Solution:** Splitting large interfaces into smaller, specific ones (`IPrinter`, `IScanner`, `IFax`).
* **Projects:**
    * **Printer System:** Refactoring a monolithic interface into granular ones so devices implement only what they actually do.

### 5. 🔴 Dependency Inversion Principle (DIP)
*"High-level modules should not depend on low-level modules. Both should depend on abstractions."*
* **The Problem:** A `ReportGenerator` class that instantiates a specific `SQLDatabase` class inside its constructor. Tightly coupled!
* **The Solution:** Depending on an interface `IDatabase`. The `ReportGenerator` doesn't care if the data comes from SQL, Oracle, or a Text File.
* **Projects:**
    * **Report System:** A flexible reporting engine that can switch data sources without changing the report logic.

---

## 🏗️ Architectural Patterns

### 💉 Dependency Injection (DI)
The practical application of the Dependency Inversion Principle.
* **Concept:** Instead of a class creating its dependencies (`new Service()`), they are "injected" into it (usually via the constructor).
* **Benefit:** Makes unit testing incredibly easy because real services can be swapped for mocks.

---

## 📂 Directory Structure
There is 3 Folders, 2 diffreent courses, and one to apply on what I've learned
Each folder contains a "Before" (Violating) and "After" (Refactored) version of the code to demonstrate the principle in action.

* **`01_SRP/`** - Notification & Logging examples.
* **`02_OCP/`** - Payment Gateway extension examples.
* **`03_LSP/`** - Bird & Vehicle hierarchy fixes.
* **`04_ISP/`** - Printer & Device interface segregation.
* **`05_DIP/`** - Report generation decoupling.

## 🛠️ Tech Stack
* **Language:** C# (.NET Core)
* **Concepts:** Abstract Classes, Interfaces, Polymorphism, DI Containers.

## 🚀 How to Run
These are Console Applications designed to demonstrate logic.

1.  Navigate to a specific principle folder (e.g., `26 - SOLID/02_OCP`).
2.  Run the project:
    ```bash
    dotnet run
    ```

---
*This repository documents my journey in mastering Backend Engineering.*
