# TaskManagement
# Task Management System

## 2.1.3.1 Overview of What Is Being Built

This project is a **Task Management System** built using **ASP.NET Core MVC** and **Entity Framework Core**. The application allows users to perform full **CRUD operations (Create, Read, Update, Delete)** on tasks along with search functionality. It demonstrates backend development, database design, MVC architecture, and proper documentation practices as required by the assignment.

## 📌 Key Features

### ✅ Task List & Search
- View all tasks in a tabular format
- Search tasks by title
- ![Task List & Search](Screenshots/task-list.png)

### ➕ Create Task
- Add new tasks with **title, status, due date, remarks, and description**
- ![Create Task](Screenshots/create-task.png)  

### ✏️ Edit Task
- Update task details and status easily
- ![Edit Task ](Screenshots/edit-task.png) 

### 🔍 Task Details View
- View complete task information including created/updated metadata
- ![Task Details](Screenshots/task-details.png)   

### 🔐 Authentication (Login & Register)
- Secure user authentication using **ASP.NET Core Identity**
  - Login Page
  - ![login](Screenshots/login.png) 
  - Register Page
  - ![Register](Screenshots/register.png) 

### 🗑️ Delete Confirmation
- Modal popup confirmation before deleting a task
- ![Delete Task](Screenshots/delete-confirmation.png)  

### 🧱 Architecture & Design
- Server-side rendered MVC views
- Clean separation of concerns using **MVC pattern**
- Session-based logout handling


---

## 2.1.3.2 Database Design

### 2.1.3.2.1 ER Diagram

```
+---------------------------+
|        AspNetUsers        |
+---------------------------+
| Id (PK)                   |
| UserName                  |
| Email                     |
| PasswordHash              |
| ...                       |
+-------------+-------------+
              |
              | 1
              |
              | *
+-------------v-------------+
|         TaskItem           |
+---------------------------+
| Id (PK)                   |
| TaskTitle                 |
| TaskDescription           |
| TaskDueDate               |
| TaskStatus                |
| TaskRemarks               |
| CreatedOn                 |
| LastUpdatedOn             |
| CreatedBy (FK → UserName) |
| LastUpdatedBy             |
+---------------------------+

```

This application currently uses a single core entity (`TaskItem`) to manage task-related information.

---

### 2.1.3.2.2 Data Dictionary

| Column Name     | Data Type     | Description                                 |
| --------------- | ------------- | ------------------------------------------- |
| Id              | int (PK)      | Unique identifier for the task              |
| TaskTitle       | nvarchar(100) | Title of the task (Required)                |
| TaskDescription | nvarchar(500) | Detailed description of the task (Required) |
| TaskDueDate     | datetime      | Due date for the task                       |
| TaskStatus      | nvarchar(50)  | Status (Pending, Completed, etc.)           |
| TaskRemarks     | nvarchar(500) | Optional additional remarks                 |
| CreatedOn       | datetime      | Record creation timestamp                   |
| LastUpdatedOn   | datetime      | Last modification timestamp                 |
| CreatedBy       | nvarchar(256) | Username who created the record             |
| LastUpdatedBy   | nvarchar(256) | Username who last modified the record       |

---

### 2.1.3.2.3 Documentation of Indexes Used

* **Primary Key Index** on `Id`
* Optional non-clustered index can be added on:

  * `TaskTitle` (to optimize search performance)

Example:

```sql
CREATE NONCLUSTERED INDEX IX_Task_TaskTitle ON Tasks(TaskTitle);
```

---

### 2.1.3.2.4 Code First or DB First Approach

✅ **Code First Approach Used**

**Reason:**

* Faster development and iteration
* Strongly typed domain models
* Easier version control of schema changes using migrations
* Ideal for small to medium-sized applications

Entity Framework Core automatically generates the database schema based on model classes.

---

## 2.1.3.3 Application Structure

### 2.1.3.3.1 SPA with API Binding

❌ Not used

### 2.1.3.3.2 Standard MVC Server-Side Rendering

✅ Used

The application follows **ASP.NET Core MVC**:

* **Models**: TaskItem entity
* **Views**: Razor (.cshtml) views
* **Controllers**: TasksController handling all HTTP requests

This approach was chosen for simplicity, maintainability, and suitability for the assignment scope.

---

## 2.1.3.4 Frontend Structure

### 2.1.3.4.1 Frontend Technology Used

* Razor Views (CSHTML)
* HTML5, CSS3
* Bootstrap (for responsive UI)

**Why:**

* Tight integration with ASP.NET Core MVC
* Faster development without separate frontend framework
* Server-side rendering improves SEO and simplicity

### 2.1.3.4.2 Web or Mobile Application

✅ **Web Application**

The application is web-based and accessible via browser.

---

## 2.1.3.5 Build and Install

### 2.1.3.5.1 Environment Details & Dependencies

* **.NET SDK**: .NET 6 / .NET 7+
* **IDE**: Visual Studio 2022 / VS Code
* **Database**: SQL Server / LocalDB
* **ORM**: Entity Framework Core
* **Packages**:

  * Microsoft.EntityFrameworkCore
  * Microsoft.EntityFrameworkCore.SqlServer
  * Microsoft.EntityFrameworkCore.Tools

---

### 2.1.3.5.2 How to Build the Project

```bash
dotnet restore
dotnet build
```

Or using Visual Studio:

* Open solution file (.sln)
* Click **Build → Build Solution**

---

### 2.1.3.5.3 How to Run the Project

```bash
dotnet ef database update
dotnet run
```

Or using Visual Studio:

* Set project as Startup Project
* Press **F5** or **Ctrl + F5**

Application will run at:

```
https://localhost:5001
```

---

## 2.1.3.6 General Documentation

### Domain Model (TaskItem)

The `TaskItem` model uses **Data Annotations** for validation and includes **audit fields** for tracking creation and modification details.

Key highlights:

* Validation using `[Required]` and `[StringLength]`
* Audit fields: `CreatedOn`, `LastUpdatedOn`, `CreatedBy`, `LastUpdatedBy`
* `CreatedOn` is explicitly controlled in code using `DatabaseGeneratedOption.None`

### DbContext Design (ApplicationDbContext)

The `ApplicationDbContext` inherits from `IdentityDbContext<IdentityUser>`, enabling seamless **ASP.NET Core Identity** integration.

Audit handling is implemented by:

* Overriding `SaveChanges()` and `SaveChangesAsync()`
* Automatically populating audit fields using `IHttpContextAccessor`
* Capturing the logged-in username or defaulting to `System`

This approach ensures:

* Centralized audit logic
* No duplication of audit code in controllers
* Consistent data integrity across all database operations

---

### Folder Structure

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

### Key Controller Responsibilities

* `Index()` – List & search tasks
* `Details()` – View task details
* `Create()` – Add new task
* `Edit()` – Update existing task
* `Delete()` – Remove task
* `Logout()` – Clear session

---

## 2.2 Assignment Objectives Coverage

✔ Backend technologies – ASP.NET Core MVC, EF Core
✔ Frontend technologies – Razor, Bootstrap
✔ Database systems – SQL Server, EF Core
✔ Problem-solving – CRUD, search, validation
✔ Documentation – Markdown-based GitHub documentation
✔ Planning & execution – Structured MVC design

---

## Conclusion

This project fulfills all requirements mentioned in the assignment document, including working demo, public GitHub hosting, proper documentation, database design explanation, and clear architectural decisions. The solution is scalable, maintainable, and ready for evaluation.  make corre er diagram 
