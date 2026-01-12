# Task Management System

A **Task Management System** built using **ASP.NET Core MVC** and **Entity Framework Core**. This application demonstrates full **CRUD operations**, search functionality, authentication, and clean MVC architecture as required by the assignment.

---

## 📌 Overview

The application allows authenticated users to manage tasks with complete lifecycle support:

* Create, view, update, and delete tasks
* Search tasks by title
* Secure authentication using **ASP.NET Core Identity**
* Audit tracking (Created/Updated metadata)

This project focuses on backend development, database design, MVC architecture, and proper technical documentation.

---

## ✨ Key Features

### ✅ Task List & Search

* View all tasks in a tabular format
* Search tasks by title

![Task List & Search](Screenshots/task-list.png)

### ➕ Create Task

* Add tasks with:

  * Title
  * Status
  * Due Date
  * Remarks
  * Description

![Create Task](Screenshots/create-task.png)

### ✏️ Edit Task

* Update task details and status

![Edit Task](Screenshots/edit-task.png)

### 🔍 Task Details

* View complete task information
* Includes created and last-updated audit details

![Task Details](Screenshots/task-details.png)

### 🔐 Authentication

* Secure login and registration using **ASP.NET Core Identity**

**Login Page**

![Login](Screenshots/login.png)

**Register Page**

![Register](Screenshots/register.png)

### 🗑️ Delete Confirmation

* Modal popup confirmation before deleting a task

![Delete Confirmation](Screenshots/delete-confirmation.png)

---

## 🧱 Architecture & Design

* Server-side rendered **ASP.NET Core MVC** application
* Clean separation of concerns using MVC pattern
* Session-based logout handling

---

## 🗄️ Database Design

### ER Diagram

```
AspNetUsers (Identity)
   └── UserName (PK)
        │
        │ 1
        │
        │ *
TaskItem
   ├── Id (PK)
   ├── TaskTitle
   ├── TaskDescription
   ├── TaskDueDate
   ├── TaskStatus
   ├── TaskRemarks
   ├── CreatedOn
   ├── LastUpdatedOn
   ├── CreatedBy (FK → UserName)
   └── LastUpdatedBy
```

![ER Diagram](Screenshots/EF.png)

---

### 📘 Data Dictionary

| Column Name     | Data Type     | Description                         |
| --------------- | ------------- | ----------------------------------- |
| Id              | int (PK)      | Unique identifier for the task      |
| TaskTitle       | nvarchar(100) | Title of the task (Required)        |
| TaskDescription | nvarchar(500) | Detailed description (Required)     |
| TaskDueDate     | datetime      | Due date of the task                |
| TaskStatus      | nvarchar(50)  | Status (Pending, Completed, etc.)   |
| TaskRemarks     | nvarchar(500) | Optional remarks                    |
| CreatedOn       | datetime      | Record creation timestamp           |
| LastUpdatedOn   | datetime      | Last modification timestamp         |
| CreatedBy       | nvarchar(256) | Username who created the task       |
| LastUpdatedBy   | nvarchar(256) | Username who last modified the task |

---

### 📈 Indexes Used

* **Primary Key Index** on `Id`
* Optional non-clustered index on `TaskTitle` for search optimization

```sql
CREATE NONCLUSTERED INDEX IX_Task_TaskTitle
ON Tasks(TaskTitle);
```

---

### 🛠️ Code First Approach

✅ **Code First (Entity Framework Core)**

**Why Code First?**

* Faster development and iteration
* Strongly typed domain models
* Easy schema versioning using migrations
* Ideal for small to medium-sized projects

---

## 🏗️ Application Structure

### MVC (Server-Side Rendering)

* **Models**: Domain entities (TaskItem)
* **Views**: Razor (.cshtml) views
* **Controllers**: Handle HTTP requests and business logic

SPA/API architecture is **not used**, as MVC suits the assignment scope.

---

## 🎨 Frontend Details

* Razor Views (CSHTML)
* HTML5, CSS3
* Bootstrap 5

**Why?**

* Seamless integration with ASP.NET Core MVC
* Rapid UI development
* Responsive design

---

## ⚙️ Build & Run Instructions

### Environment & Dependencies

* .NET SDK: **.NET 6 / .NET 7+**
* IDE: Visual Studio 2022 / VS Code
* Database: SQL Server / LocalDB
* ORM: Entity Framework Core

### NuGet Packages

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

---

### Build the Project

```bash
dotnet restore
dotnet build
```

Or in Visual Studio:

* Open the `.sln` file
* Select **Build → Build Solution**

---

### Run the Project

```bash
dotnet ef database update
dotnet run
```

Or in Visual Studio:

* Set project as Startup Project
* Press **F5** or **Ctrl + F5**

Application URL:

```
https://localhost:5001
```

---

## 🧠 Internal Design Details

### Domain Model (TaskItem)

* Uses Data Annotations for validation
* Includes audit fields:

  * CreatedOn
  * LastUpdatedOn
  * CreatedBy
  * LastUpdatedBy

### DbContext (ApplicationDbContext)

* Inherits from `IdentityDbContext<IdentityUser>`
* Integrates ASP.NET Core Identity
* Overrides `SaveChanges()` / `SaveChangesAsync()` to:

  * Auto-populate audit fields
  * Capture logged-in username via `IHttpContextAccessor`

---

## 📁 Folder Structure

```
TaskManagement/
│── Controllers/
│   └── TasksController.cs
│── Models/
│   └── TaskItem.cs
│── Data/
│   └── ApplicationDbContext.cs
│── Views/
│   └── Tasks/
│── wwwroot/
│── Program.cs
│── appsettings.json
```

---

## 🎯 Assignment Objectives Coverage

✔ Backend Technologies – ASP.NET Core MVC, EF Core
✔ Frontend Technologies – Razor, Bootstrap
✔ Database Systems – SQL Server
✔ CRUD Operations & Search
✔ Authentication & Authorization
✔ Clean Documentation (GitHub-ready)

---

## ✅ Conclusion

This project fulfills all assignment requirements, including:

* Functional CRUD operations
* Secure authentication
* Database design with ER diagram
* Proper architectural decisions
* Clear and structured GitHub documentation

The solution is **scalable, maintainable, and ready for evaluation**.
