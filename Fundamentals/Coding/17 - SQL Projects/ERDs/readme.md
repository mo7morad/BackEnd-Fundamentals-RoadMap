# Course 17: Database - SQL (Projects & Practice)

This directory contains the database schemas, design documents, and SQL solutions for **Course 17** of the Backend Engineering Roadmap.

This course serves as the practical application of **Course 15 (Database Foundations)**. I moved from drawing ERD diagrams to implementing fully functional **Relational Databases** in SQL Server. I designed schemas for five different industries and solved over 50 advanced query problems to master data manipulation.

## 📂 Capstone Database Projects

I designed and implemented the Relational Schema for five distinct systems. Each project includes the full SQL Script (`.bak` backup) and the requirement documentation.

### 1. 🏥 [Simple Clinic System](./Projects/Clinic)
**[📂 Click to View Project](./Projects/Clinic)**
A management system for a small medical clinic.
* **Entities:** Patients, Doctors, Appointments, Medical Records.
* **Key Challenge:** Handling appointment scheduling and ensuring data integrity between patients and assigned doctors.

### 2. 📚 [Simple Library System](./Projects/Library)
**[📂 Click to View Project](./Projects/Library)**
A tracking system for book lending.
* **Entities:** Books, Members, Borrowing Records, Fines.
* **Key Challenge:** Designing a system to track who has which book and calculating due dates.

### 3. 🥋 [Karate Club System](./Projects/KarateClub)
**[📂 Click to View Project](./Projects/KarateClub)**
A membership management database for a sports club.
* **Entities:** Members, Belt Ranks, Instructors, Payments.
* **Key Challenge:** Managing hierarchical data (Belt Ranks) and tracking payment history for members.

### 4. 🚗 [Car Rental System](./Projects/CarRental)
**[📂 Click to View Project](./Projects/CarRental)**
A booking system for vehicle rentals.
* **Entities:** Vehicles, Customers, Bookings, Returns, Maintenance.
* **Key Challenge:** Handling date ranges to prevent double-booking of vehicles and calculating rental fees.

### 5. 🛒 [Online Store System](./Projects/OnlineStore)
**[📂 Click to View Project](./Projects/OnlineStore)**
A full E-commerce backend schema.
* **Entities:** Products, Categories, Customers, Orders, Order Details.
* **Key Challenge:** Implementing the "Order Details" many-to-many relationship to allow multiple products per single order.

---

## 🧠 SQL Problem Solving (50+ Challenges)

Beyond system design, I solved a massive set of SQL problems using a complex **Vehicle Database** and **HR Database**.

### 🔍 Query Mastery
* **Complex Filtering:** Using `WHERE`, `BETWEEN`, `IN`, and `LIKE` with Wildcards.
* **Aggregation:** generating reports using `COUNT`, `SUM`, `AVG`, `MAX`, and `GROUP BY`.
* **Advanced Joins:**
    * **Inner Joins:** Connecting Vehicles to Makes and Models.
    * **Self Joins:** Finding Employees and their Managers within the same table.
    * **Outer Joins:** Finding "orphan" data (e.g., Makes with no Vehicles sold).
* **Subqueries & Views:** Creating virtual tables to simplify complex reporting logic.

### 🚗 Vehicle Database Challenges
Specific problems solved included:
* *"Get all vehicles manufactured between 1950 and 2000."*
* *"Calculate the percentage of vehicles per DriveType (FWD/RWD)."*
* *"Find the top 3 manufacturers with the highest number of models."*
* *"Identify vehicles with missing data (NULL doors or engine descriptions)."*

---

## 🛠️ Tech Stack
* **RDBMS:** Microsoft SQL Server 2022
* **Tool:** SQL Server Management Studio (SSMS)
* **Language:** T-SQL (Transact-SQL)
* **Concepts:**
    * **DDL:** `CREATE`, `ALTER`, `DROP` (Table structure).
    * **DML:** `INSERT`, `UPDATE`, `DELETE`, `SELECT` (Data manipulation).
    * **Normalization:** Ensuring tables are in **3NF** (Third Normal Form) to reduce redundancy.

## 🚀 How to Use the Files
1.  **Requirements:** Open the `.pdf` files to see the business rules for each project.
2.  **Database:** The `.bak` files are **SQL Server Backups**.
    * Open **SSMS**.
    * Right-click **Databases** -> **Restore Database**.
    * Select **Device** and browse to the `.bak` file to load the full schema and data.

---
*This repository documents my journey in mastering Backend Engineering.*
