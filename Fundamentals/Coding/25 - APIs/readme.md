# Course 25: Web APIs & RESTful Architecture

This directory contains my explorations, exercises, and full-stack projects for **Course 25** of the Backend Engineering Roadmap.

In this phase, I transitioned from building standalone desktop apps to building **Distributed Systems**. I started by exploring low-level **Win32 APIs** to control the Operating System, then moved to building modern **RESTful Web APIs** using ASP.NET Core. I learned to structure endpoints, handle HTTP verbs, and connect these APIs to the Database architectures I built in previous courses.

## 📂 Topics Covered

The course is divided into three distinct phases of API understanding:

### 1. 🖥️ Desktop & Win32 APIs
Before touching the web, I learned what an API truly is by interacting with Windows itself using `[DllImport]`.
* **System Control:** Changing desktop wallpapers, shutting down the PC, and reading battery levels programmatically.
* **Office Automation:** Controlling Word, Excel, and Outlook (sending emails) via code.
* **Process Management:** Listing and managing running Windows processes.

### 2. 🌐 Web & REST Fundamentals
Understanding the language of the web (HTTP).
* **Data Formats:** XML vs. **JSON** (the standard for modern APIs).
* **HTTP Verbs:** `GET` (Read), `POST` (Create), `PUT` (Update), `DELETE` (Remove).
* **Status Codes:** Understanding the difference between `200 OK`, `201 Created`, `400 Bad Request`, `404 Not Found`, and `500 Server Error`.
* **DTOs (Data Transfer Objects):** Learning to decouple the Database Schema (Models) from the API Response to ensure security and flexibility.

### 3. 🏗️ ASP.NET Core Web API
Building the actual services.
* **Routing:** How URLs (`/api/students/1`) map to C# Controller methods.
* **Model Binding:** Automatically mapping JSON request bodies to C# objects.
* **Media Handling:** Endpoints for uploading and serving images files.

---

## 🏆 Projects & Architecture

This repository is organized into specific folders reflecting the evolution of my API skills.

### 1. ⚙️ [Win32_System_Integrations](./Win32_APIs)
A collection of Console Applications utilizing unmanaged code.
* **WallpaperChanger:** Uses `user32.dll` to set the desktop background.
* **SystemInfo:** Retrieval of screen resolution and power status.
* **OfficeInterop:** Scripts to generate reports in Excel and send them via Outlook.

### 2. 🎓 [StudentAPI_InMemory (v1 - v7)](./StudentAPI_InMemory)
My first RESTful API. To focus purely on HTTP logic, this version uses a **static in-memory list** instead of a database.
* **Evolution:**
    * **v1:** `GET /api/students` - Returns all students.
    * **v2-v4:** Added filtering (`/passed`, `/avg`) and path parameters (`/{id}`).
    * **v5:** `POST` - Implementing creation logic with `201 Created` responses.
    * **v6-v7:** `DELETE` and `PUT` - Completing the CRUD cycle.
* **Client App:** A C# Console Application using `HttpClient` to consume these endpoints, proving that the client is decoupled from the server.

### 3. 🗄️ [StudentAPI_Database (3-Tier)](./StudentAPI_Database)
**The Capstone Project.**
I refactored the In-Memory API to connect to a real **SQL Server Database**, reusing the **3-Tier Architecture** (Business Logic & Data Access Layers) from Course 18.
* **Architecture:**
    * **Controller:** Handles HTTP Requests and DTO mapping.
    * **Business Layer:** Validates logic (e.g., "Student age must be > 18").
    * **Data Layer:** Executes ADO.NET commands to SQL Server.
* **Features:** Full CRUD with persistent storage.

### 4. 🖼️ [Media_Server](./Media_Server)
A specialized API project for file management.
* **Upload:** `POST /api/files/upload` accepts `IFormFile` to save images to the server's disk.
* **Retrieve:** `GET /api/files/{filename}` streams image data back to the client.

---

## 🛠️ Technical Highlights

### 🔁 DTO Implementation
Instead of returning the raw `Student` DB Entity, I implemented DTOs to control what data is exposed:
```csharp
// Raw Entity (Hidden)
public class Student {
    public int ID { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; } // Never expose this!
}

// DTO (Exposed)
public class StudentDTO {
    public string FullName { get; set; }
    public double AverageGrade { get; set; }
}
