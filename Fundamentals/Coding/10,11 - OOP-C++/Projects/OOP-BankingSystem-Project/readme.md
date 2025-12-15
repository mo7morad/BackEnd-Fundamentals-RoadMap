# Course 11 Project: Enterprise Banking System (OOP)

This directory contains the **Enterprise Banking System**, the final and most advanced Capstone Project for **Course 10 (OOP Level 1)** of the Backend Engineering Roadmap.

This project is a complete re-engineering of the previous Banking System. It transitions from a simple procedural console app to a **Production-Grade Object-Oriented Application**. It features a robust multi-tier architecture, advanced security with bitwise permissions, transaction logging, and a full currency exchange module.

## 📂 System Architecture

The project follows a strict **Layered Architecture** to separate Presentation (UI), Business Logic, and Data Access.

### 1. 🖥️ Presentation Layer (UI Screens)
Handles all user interactions. Each "Screen" is a class inheriting from a base `clsScreen`.
* **Main Dashboard:** `clsMainScreen` acts as the central router, directing users to sub-systems.
* **Client Management:** Screens for Adding, Deleting, Updating, and Finding Clients.
* **User Management:** Admin interfaces to manage system users (Admins/Tellers) and their permissions.
* **Transactions:** A dedicated submenu for Deposits, Withdrawals, and Transfers.
* **Currency Exchange:** A complete sub-system for listing rates, calculating conversions, and updating exchange rates.

### 2. 🧠 Business Logic Layer (Core Classes)
The "Brains" of the application. These classes model real-world entities and enforce business rules.
* **`clsBankClient.h`**: Manages client data, balances, and pin codes. Contains logic for Transfer operations and checking balance sufficiency.
* **`clsUser.h`**: Manages system users and implements the **Security System** (Permissions).
* **`clsCurrency.h`**: Handles currency data (Country, Code, Rate) and conversion logic (to/from USD).

### 3. 🛡️ Security & Logging Layer
* **Bitwise Permissions:** The system uses a bitmask system to grant granular access (e.g., a user can be allowed to `AddClient` (2) and `DeleteClient` (8) but not `ShowTransactions` (32)).
* **Login Registers:** Tracks every successful login attempt (User, Time, Permissions) to a log file.
* **Transfer Logs:** specific log for auditing money transfers between accounts.

## ✨ Key Features

### 1. 🌍 Currency Exchange System
A new module that allows the bank to handle multi-currency operations.
* **Real-time Conversion:** Calculator to convert between any two currencies (using USD as the intermediate base).
* **Rate Management:** Admins can update the daily exchange rate for any currency.

### 2. 💸 Advanced Transactions
* **Safe Transfers:** Atomically transfers money from Source to Destination. Checks for sufficient funds and prevents transfers to the same account.
* **Transaction History:** Every transfer is recorded in `TransferLog.txt` for auditing.

### 3. 🔐 Enterprise Security
* **Authentication:** Users must login with Username/Password.
* **Authorization:** Every screen checks `CheckAccessRights()` before loading. If the user lacks the specific permission bit, access is denied.
* **Failed Login Lockout:** The system tracks failed attempts. After 3 failed tries, the system locks or alerts (simulated).

## 🛠️ Tech Stack
* **Language:** C++
* **Architecture:** Layered OOP (Presentation, Business, Data).
* **Data Storage:** Flat Files (`Clients.txt`, `Users.txt`, `Currencies.txt`, `TransferLog.txt`, `LoginRegister.txt`).
* **Design Patterns:**
    * **Template Method:** Used in Input Validation.
    * **Static Factory:** Used extensively for Screen classes (e.g., `clsMainScreen::ShowMainMenu`).

## 🚀 How to Run

1.  **Compile:**
    Compile the main entry file (which includes all headers).
    ```bash
    g++ main.cpp -o BankSystem
    ```
2.  **Run:**
    ```bash
    ./BankSystem
    ```
    *Default Admin Credentials:* `User: Admin`, `Pass: 1234`

## 📝 Key Takeaways
* **Architectural Discipline:** This project forced me to adhere to strict layering. UI code *never* touches the file system directly; it always goes through a Business Object.
* **Scalability:** Adding the "Currency Exchange" system was seamless because the existing architecture allowed plugging in new modules without rewriting the core.
* **Auditability:** Implemented logging for security (Logins) and finance (Transfers), a requirement for any real-world banking software.

---
*This repository documents my journey in mastering Backend Engineering.*
