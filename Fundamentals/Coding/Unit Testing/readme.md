# Course: Unit Testing & TDD Fundamentals

This directory contains my test projects, exercises, and notes for the **Unit Testing** phase of the Backend Engineering Roadmap.

In this phase, I started to learn about "testing manually by running the app" to **Automated Testing**. I learned how to write code that verifies my code, ensuring that new changes don't break existing functionality (Regression Testing). I learned also about the **MSTest Framework**, the **AAA Pattern**, and how to achieve high **Code Coverage**.

## 📂 Topics Covered

The course focuses on the fundamentals of writing robust unit tests in C#.

### 1. 🧪 Testing Basics
* **Manual vs. Automated:** Understanding why manual testing is unscalable and error-prone.
* **The AAA Pattern:** Structuring every test into three distinct phases:
    * **Arrange:** Setup objects and variables.
    * **Act:** Execute the function being tested.
    * **Assert:** Verify the result matches the expectation.

### 2. 🛠️ MSTest Framework
* **Attributes:**
    * `[TestClass]`: Marking a class as a container for tests.
    * `[TestMethod]`: Marking a method as an executable test case.
* **Test Lifecycle:**
    * `[TestInitialize]` & `[TestCleanup]`: Running code before/after *every* test.
    * `[ClassInitialize]` & `[ClassCleanup]`: Running code once per *class*.

### 3. 🎯 Assertions (The Core)
I mastered the `Assert` class to verify different types of outcomes:
* **Equality:** `Assert.AreEqual()`, `Assert.AreNotEqual()`.
* **Boolean:** `Assert.IsTrue()`, `Assert.IsFalse()`.
* **Objects:** `Assert.AreSame()` (Reference check) vs `Assert.AreEqual()` (Value check).
* **Strings:** `StringAssert.StartsWith()`, `StringAssert.Contains()`.
* **Collections:** `CollectionAssert.AreEqual()`, `CollectionAssert.Contains
