# Course 21: Advanced SQL & T-SQL Concepts

This directory contains my scripts, exercises, and examples for **Course 21** of the Backend Engineering Roadmap.

In this phase, I transitioned from writing static SQL queries to building **Dynamic Database Logic**. I mastered the programming side of SQL Server (T-SQL), including Control of Flow, Error Handling, and sophisticated database objects like Triggers, Cursors, and Window Functions.

## 📂 Topics & Scripts

The course covers advanced T-SQL capabilities categorized by functionality:

### 1. ⌨️ T-SQL Programming Fundamentals
Treating SQL like a programming language.
* **Variables:** Declaring (`DECLARE @Name`) and assigning values for dynamic queries.
* **Control of Flow:**
    * **IF/ELSE:** executing logic based on conditions (e.g., checking if a record exists).
    * **CASE Statement:** Implementing complex "Switch" logic directly in `SELECT` or `UPDATE` statements.
    * **Loops:** Using `WHILE` to iterate over data or counters (since T-SQL lacks `FOR` loops).
* **Blocks:** Using `BEGIN...END` to group multiple statements.

### 2. 🛡️ Error Handling & Transactions
Ensuring data integrity and robust execution.
* **Try...Catch:** Catching runtime errors gracefully instead of crashing scripts.
* **Transactions:** implementing `BEGIN TRAN`, `COMMIT`, and `ROLLBACK` to ensure "All or Nothing" execution (e.g., Bank Transfers).
* **Data Validity:** Using `@@ERROR` and `@@ROWCOUNT` to validate the success of previous operations.

### 3. ⚙️ Database Programmability
Reusable code blocks stored in the database.
* **Stored Procedures:** Pre-compiled scripts that accept parameters (Input/Output) and return values.
* **Functions:**
    * **Scalar:** Returns a single value (e.g., `CalculateTax(@Amount)`).
    * **Table-Valued:** Returns a full table result set, usable in `JOIN` clauses.
* **Triggers:**
    * **AFTER Triggers:** Logic that runs *after* an Insert/Update/Delete (e.g., Audit Logging).
    * **INSTEAD OF Triggers:** Logic that intercepts an action (e.g., preventing deletion of critical data).

### 4. 🚀 Advanced Data Manipulation
* **Window Functions:** `ROW_NUMBER()`, `RANK()`, `DENSE_RANK()`, and `NTILE()` for advanced analytical reporting.
* **CTE (Common Table Expressions):** Creating temporary result sets for readability and recursive queries (e.g., Org Charts).
* **Temporary Tables:** Using `#LocalTemp` and `##GlobalTemp` tables for intermediate data processing.
* **Dynamic SQL:** Building and executing SQL strings at runtime (`sp_executesql`) to handle flexible search criteria.

### 5. 🐢 Cursors
* **Row-by-Row Processing:** Iterating through result sets one row at a time (used sparingly due to performance cost vs. Set-based operations).

## 🏆 Key Implementations

This repository includes scripts for:
* **Audit System:** A Trigger-based system that automatically logs changes to an `Employees` table into an `AuditHistory` table.
* **Bank Transfer:** A Transaction-based Stored Procedure that safely moves money between accounts, rolling back if funds are insufficient.
* **Paging Logic:** Using `OFFSET` and `FETCH NEXT` to retrieve data in "Pages" (e.g., Rows 11-20).

## 🛠️ Tech Stack
* **Database:** Microsoft SQL Server
* **Language:** T-SQL (Transact-SQL)
* **Tools:** SSMS (SQL Server Management Studio)

---
*This repository documents my journey in mastering Backend Engineering.*
