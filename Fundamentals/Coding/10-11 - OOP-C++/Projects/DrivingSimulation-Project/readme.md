# Course 11 Project: Driving Simulation (OOP)

This directory contains the **Driving Simulation**, the second Capstone Project for **Course 10 (OOP Level 1)**.

While the previous project focused on Data Management, this project focuses on **State Management** and **Simulation Logic**. It simulates a driving experience where the user can customize their vehicle configuration (Car Type, Wheel Type) and run a physics-based simulation on different tracks.

## 📸 Application Demo

Here is the flow of setting up and running a simulation:

### 1. Main Dashboard
The control center where users can access configuration settings or start the race.

![Main Menu](../../../../../Repo%20Images/DrivingSimulation1.png)

### 2. Vehicle Configuration
The system allows independent modification of the Car Body and Wheel Type, demonstrating persistent state management.

![Change Car](../../../../../Repo%20Images/DrivingSimulation2.png)
![Change Wheels](../../../../../Repo%20Images/DrivingSimulation3.png)

### 3. Track Selection
Users define the environment and the distance (in Kilometers) for the simulation.

![Choose Track](../../../../../Repo%20Images/DrivingSimulation4.png)

### 4. The Simulation Engine
The final output where the system combines the configured Car, Wheels, and Track variables to calculate travel time based on user speed.

![Start Racing](../../../../../Repo%20Images/DrivingSimulation5.png)

---

## 📂 System Architecture

The project maintains the strict **Layered Architecture** established in the previous project:

### 1. 🖥️ Presentation Layer (`headers/screens/`)
Handles the menu system and user interaction.
* **`clsMainScreen.h`**: The main dashboard. It directs users to configuration screens or the racing start.
* **`ChangeCarScreen.h`**: Allows the user to switch the vehicle chassis (Racing, Off-Road, Family).
* **`ChangeWheelsScreen.h`**: Allows the user to swap tires independently of the car body.
* **`ChooseTrackScreen.h`**: Sets the environment variables (Track Type and Length in KM).
* **`StartRacingScreen.h`**: The core simulation engine. It calculates physics (Time = Distance / Speed) and runs a loop to print hourly progress.

### 2. 🏎️ Business Objects (`headers/core/`)
Models the physical entities in the simulation.
* **`Car.h`**: The base class representing the vehicle. It uses **Virtual Functions** (`GetCarType`, `GetWheelsType`) to define behavior. It encapsulates the state of the engine and wheels.
* **`RacingCar.h` / `OffRoadCar.h` / `FamilyCar.h`**: Derived classes that inherit from `Car`, demonstrating **Inheritance** and **Polymorphism** (overriding base behavior).

### 3. 🛠️ Utilities (`headers/lib/`)
* **`clsInputValidate.h`**: Ensures the user enters valid speeds and menu choices, preventing simulation crashes.
* **`clsScreen.h`**: The abstract base class for all UI screens, providing standard headers and date display.

## 🎮 Simulation Logic

The core feature is the **StartRacingScreen**, which performs the following:
1.  **Validation:** Checks if a Track and Length have been selected.
2.  **Input:** Asks the user for a driving speed (km/h).
3.  **Calculation:** Computes total travel time:
    $$Time = \frac{\text{Track Length}}{\text{Speed}}$$
4.  **Loop:** Simulates the drive hour-by-hour, reporting the distance covered until the destination is reached.

## 🛠️ Tech Stack
* **Language:** C++
* **Paradigm:** Object-Oriented Programming (OOP)
* **Concepts:**
    * **Virtual Functions:** Used in `Car.h` to allow derived classes to return different types.
    * **State Management:** The system tracks the *current* car and *current* track globally across different screens.
    * **Input Validation:** using Template classes to handle numerical inputs.

## 🚀 How to Run

1.  **Compile:**
    ```bash
    g++ main.cpp -o DrivingSim
    ```
2.  **Run:**
    ```bash
    ./DrivingSim
    ```

## 📝 Key Takeaways
* **Object State:** I learned how to modify an object's state (e.g., changing wheels) in one screen and have that change reflect in the final simulation screen.
* **Polymorphism:** Understanding how `Car` can behave differently depending on its configuration.
* **Simulation Loops:** learned how to map mathematical formulas (Physics) into code loops to create a sense of progression.

---
*This repository documents my journey in mastering Backend Engineering.*
