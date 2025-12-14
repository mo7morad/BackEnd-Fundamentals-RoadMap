# Course 20: Advanced C# Programming & Architecture

This directory contains the advanced concepts, architectural patterns, and custom controls developed for **Course 20** of the Backend Engineering Roadmap.

In this phase, I transitioned from writing working code to writing **professional, scalable, and decoupled code**. I mastered the advanced features of the .NET ecosystem, including **Asynchronous Programming**, **Reflection**, **Cryptography**, and **Custom User Controls**.

## 📂 Topics & Architectures

The course covers five major pillars of advanced C# development:

### 1. 📢 Events, Delegates & Lambdas
The foundation of decoupled architecture.
* **Delegates:** passing methods as parameters using `Func`, `Action`, and `Predicate`.
* **Events:** Implementing the **Publisher/Subscriber** pattern (e.g., News Publisher, Temperature Monitor).
* **Lambdas:** Writing concise, inline code blocks to replace verbose delegate definitions.
* **Form Communication:** Sending data between WinForms loosely coupled using Delegates instead of direct object references.

### 2. ⚡ Concurrency & Asynchronous Programming
Building responsive and high-performance applications.
* **Multithreading:** Managing the `Thread` class, handling **Race Conditions**, and using Synchronization (Locks).
* **TPL (Task Parallel Library):** Moving to the modern `Task` based pattern.
* **Async/Await:** Writing non-blocking I/O code to keep the UI responsive.
* **Parallel Class:** Using `Parallel.For` and `Parallel.ForEach` to utilize multi-core processors for data processing.

### 3. 🔐 Security & Cryptography
Implementing industry-standard security measures.
* **Hashing:** One-way data masking using SHA256 (for passwords).
* **Symmetric Encryption:** Encrypting data with a shared key (AES).
* **Asymmetric Encryption:** Secure communication using Public/Private key pairs (RSA).

### 4. 🧰 Advanced .NET Internals
* **Reflection:** Inspecting assembly metadata at runtime to dynamically create objects or invoke methods.
* **Attributes:** Creating custom metadata tags (`[Validation]`) to enforce rules or control serialization.
* **Serialization:** Converting objects to **XML**, **JSON**, and **Binary** for storage or transmission.
* **Generics:** Writing type-safe, reusable code structures.

### 5. 🖥️ System Interaction & Logging
* **Windows Registry:** Reading and writing configuration data to the OS registry.
* **Event Log:** Logging application errors and info to the Windows Event Viewer.
* **App.config:** Managing application settings securely.

---

## 🏆 Applications

To apply these concepts, I built several complex UI components and Logic Systems.

### 1. 🚦 Traffic Light Control (User Control)
A reusable visual component encapsulating the logic of a traffic signal.
* **Features:** Configurable timer, automatic state switching (Red -> Yellow -> Green), and custom events triggers when the light changes.

### 2. 🎱 Pool Club Management System
A graphical interface for managing pool tables.
* **User Control:** Each "Table" is a self-contained control with its own timer, hourly rate calculation, and status (Available/Busy).
* **Architecture:** The main form manages a collection of these controls dynamically.

### 3. 📨 Logger & News System
A demonstration of the Observer Pattern.
* **News Publisher:** An object that broadcasts events.
* **Subscribers:** Multiple distinct classes (EmailService, SMSService) that react to the same event differently.

---

## 🛠️ Technical Highlights

### ⚡ Async/Await Pattern
Refactoring blocking code to asynchronous tasks:
```csharp
// Old Way (Freezes UI)
void DownloadData() { 
    client.DownloadFile(url, path); 
}

// New Way (Responsive UI)
async Task DownloadDataAsync() { 
    await Task.Run(() => client.DownloadFile(url, path)); 
}
