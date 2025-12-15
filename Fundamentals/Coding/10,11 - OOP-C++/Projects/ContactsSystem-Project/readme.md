# Course 11 Project: Contact Management System (OOP)

This directory contains the **Contact Management System**, the first Capstone Project for **Course 10 (OOP Level 1)** of the Backend Engineering Roadmap.

This project marks a shift from writing "scripts" to building **Architected Software**. It utilizes a layered structure to separate the **User Interface (Screens)** from the **Business Logic (Core)** and **Helper Utilities (Lib)**.

## 📂 System Architecture

The project is organized into a modular folder structure to enforce separation of concerns:

### 1. 🖥️ Presentation Layer (`headers/screens/`)
These classes handle all user interaction. They display menus, accept input, and call the Core layer to perform actions. They never interact with the file system directly.
* **`clsMainScreen.h`**: The central dashboard that routes the user to other sub-screens.
* **`clsContactsListScreen.h`**: Formats and displays the list of contacts in a table view.
* **`clsAddNewContactScreen.h`**: A form-like screen to input new contact details.
* **`clsUpdateContactScreen.h`**: Allows modifying specific fields (Name, Phone, Email) of an existing contact.
* **`clsFindContactScreen.h`**: Search interface supporting multiple search criteria (ID, Name, Email, Phone).
* **`clsDeleteContactScreen.h`**: Safe deletion flow with confirmation prompts.

### 2. 🧠 Business Logic & Data Layer (`headers/core/`)
These classes model the real-world entities and handle data persistence.
* **`clsPerson.h`**: The base class containing common attributes (Name, Phone, Email).
* **`clsContact.h`**: Inherits from `clsPerson`. It manages the specific business rules for contacts and handles **File I/O** (CRUD operations on `contacts.txt`). It includes logic to convert objects to string lines and vice versa.

### 3. 🛠️ Utility Layer (`headers/lib/`)
Reusable static libraries that can be used across any project.
* **`clsInputValidate.h`**: A generic **Template Class** to validate user input (e.g., ensuring a number is within range, reading strings safely).
* **`clsString.h`**: My custom string manipulation library (Split, Join, Trim, Invert Case, etc.).
* **`clsDate.h`**: The comprehensive Date library built in previous courses.

## ✨ Features

* **Full CRUD System:** Create, Read, Update, and Delete contacts.
* **Multi-Criteria Search:** Find contacts by ID, Full Name, Phone Number, or Email.
* **Input Validation:** Prevents the system from crashing by validating all user inputs (e.g., preventing invalid menu choices).
* **Persistent Storage:** All data is saved to `contacts.txt`, so it remains available after restarting the application.
* **Scalable Design:** New features (like a "Log" screen) can be added simply by creating a new Screen class without breaking existing code.

## 🛠️ Tech Stack
* **Language:** C++
* **Paradigm:** Object-Oriented Programming (OOP)
* **Concepts:**
    * **Inheritance:** (`clsContact` inherits `clsPerson`, Screens inherit `clsScreen`).
    * **Encapsulation:** All data fields are private and accessed via properties.
    * **Templates:** Used in `clsInputValidate` to handle different number types (`int`, `double`, etc.).
    * **Static Methods:** Used for screen controllers and utility libraries to avoid unnecessary object instantiation.

## 🚀 How to Run

1.  **Compile:**
    Since the project is split across multiple files, you need to compile the main entry point which includes the headers.
    ```bash
    g++ main.cpp -o ContactApp
    ```
2.  **Run:**
    ```bash
    ./ContactApp
    ```

## 📝 Key Takeaways
* **Separation of Concerns:** I learned why it's critical to keep the "Code that prints to screen" separate from the "Code that saves to disk."
* **Header Files Management:** Learned how to structure `.h` files and use `#pragma once` to prevent circular dependency errors.
* **Inheritance in Practice:** Used inheritance not just for code reuse (`clsPerson`), but for enforcing a common structure across UI screens (`clsScreen`).

---
*This repository documents my journey in mastering Backend Engineering.*
