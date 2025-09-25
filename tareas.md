# 🐾 Week 1 Tasks: Patient & Pet Registration  

---

## 🎯 Goal  
Register and consult patients directly from the console to have an initial control of basic information.  

---

## ⚙️ Environment Setup  
- [x] Download and install the **.NET SDK** compatible with C#.  
- [x] Configure a recommended editor (**Visual Studio** or **VS Code**).  
- [x] Create a simple console program to verify the environment works.  

---

## 🏗️ Project Setup  
- [x] Create a console project named `ClinicaSalud`.  
- [x] Organize the folder structure (create a `Models` folder).  
- [x] Configure `Program.cs` as the entry point of the application.  

---

## 👤 Patient Management  
- [x] Create the `Patient` class inside `Models` with properties:  
  - `Id` (int)  
  - `Name` (string)  
  - `Age` (int)  
  - `Symptom` (string)  
- [x] Test creating `Patient` objects in `Program.cs`.  
- [x] Declare a list of patients in `Program.cs`.  
- [x] Create a `PatientService` class to separate responsibilities.  
- [x] Implement **RegisterPatient** method.  
- [x] Implement **ListPatients** method.  
- [x] Implement **SearchPatientByName** method.  

---

## 📋 Main Menu  
- [x] Design a menu with options:  
  1️⃣ Register patient  
  2️⃣ List patients  
  3️⃣ Search patient  
  4️⃣ Exit  
- [x] Implement a `while` loop to repeat the menu until exit.  
- [x] Implement option navigation using `switch-case`.  

---

## ⚠️ Error Handling  
- [x] Add basic error handling with `try-catch`.  
- [ ] Validate that the entered age is an integer.  
- [ ] Catch exceptions when converting data.  
- [ ] Show user-friendly messages when invalid input is provided.  

---

> ✅ You can mark completed tasks by adding `x` inside the brackets `[x]`.  
