# Course 18: C# & Database Connectivity (ADO.NET)

This directory contains my projects, exercises, and architectural patterns for **Course 18** of the Backend Engineering Roadmap.

In this phase, I learned how to connect C# applications to SQL Server using **ADO.NET**. I moved beyond writing simple queries to building a robust **3-Tier Architecture** that separates Data Access, Business Logic, and the User Interface.

## 📂 Topics Covered

The course focused on three main pillars of backend development:

### 1. 🔌 ADO.NET Fundamentals
* **Connection:** Establishing secure connections to SQL Server using `SqlConnection`.
* **CRUD Operations:**
    * **Create:** Inserting records and retrieving the new Auto-ID (`SCOPE_IDENTITY()`).
    * **Read:** Fetching data using `SqlDataReader` for performance vs `DataTable` for flexibility.
    * **Update/Delete:** Executing parameterized commands to prevent SQL Injection.
* **Disconnected Mode:** Using `SqlDataAdapter` and `DataSet` to work with data offline and sync changes later.

### 2. 🏗️ 3-Tier Architecture
I refactored my monolithic code into three distinct layers to ensure maintainability and scalability:
* **Presentation Layer (PL):** The UI (Console or WinForms) that interacts with the user.
* **Business Logic Layer (BLL):** Validates data (e.g., "Is this email valid?") before passing it to the database.
* **Data Access Layer (DAL):** The only layer that talks to the database. It executes queries and returns generic data structures.

### 3. 🧠 In-Memory Data Structures
* **DataTable:** A memory representation of a single SQL table.
* **DataView:** A filtered/sorted view of a DataTable (like a virtual SQL View but in RAM).
* **DataSet:** A collection of DataTables with relationships, simulating a mini-database in memory.

---

## 🏆 Capstone Project: Contacts Manager (3-Tier)

I built a complete **Contacts Management System** that allows users to manage a directory of people (Names, Emails, Phones, Countries). I implemented this twice to prove that the **Business and Data layers** are reusable across different interfaces.

### 🏛️ System Architecture

| Layer | Responsibility | Example Class |
| :--- | :--- | :--- |
| **Presentation** | User Input & Output (Console/Forms) | `frmAddContact.cs` |
| **Business Logic** | Validation & Rules | `clsContact.cs` |
| **Data Access** | SQL Commands & Connections | `clsContactDataAccess.cs` |

### 🚀 Implementation 1: Console App
A command-line interface to interact with the system.
* **Focus:** Understanding the logic flow without UI distractions.
* **Key Feature:** Creating a generic "DTO" (Data Transfer Object) to pass data between layers.

### 🚀 Implementation 2: Windows Forms App
A GUI-based version reusing the *exact same* Business and Data layers from the Console App.
* **Data Binding:** Linking `DataGridView` directly to `DataTables` returned from the BLL.
* **Event Handling:** Using events to trigger database updates (e.g., clicking "Save").

---

## 🛠️ Technical Highlights

### 🔒 Parameterized Queries
Instead of string concatenation (which is dangerous), I used `SqlParameter` to safely handle user input and avoid SQL injections:
```csharp
SqlCommand command = new SqlCommand("SELECT * FROM Contacts WHERE Name = @Name", connection);
command.Parameters.AddWithValue("@Name", txtName.Text);
