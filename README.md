# 🎫 Help Desk Management System

A three-tier ASP.NET Core application designed to manage support tickets through a RESTful Web API, an MVC front-end, and a unit testing project.

---

## 📌 Overview

The **Help Desk Management System** is built using a layered architecture that separates the API, MVC client, and data access components. The MVC application communicates with the Web API using **HttpClient**, while **Entity Framework Core** handles database operations.

---

## 🔗 Repository

**GitHub:**  
https://github.com/Shreyb7/Help--Desk-Ticket-Management-System-IN26011418

---

## ✨ Features

- 📝 Create new support tickets
- 📋 View all tickets
- 🔍 View ticket details
- ✏️ Edit ticket information
- 🗑️ Delete tickets
- 🔎 Search tickets by status
- 📊 Dashboard showing:
  - Total Tickets
  - Open Tickets
  - Closed Tickets
- 🌐 RESTful Web API
- 💾 SQL Server database using Entity Framework Core
- 🧪 Unit testing with xUnit and Moq

---

## 🛠️ Technologies Used

- ⚙️ ASP.NET Core Web API
- 🖥️ ASP.NET Core MVC
- 🗄️ Entity Framework Core
- 💾 SQL Server
- 💻 C#
- 🎨 Bootstrap 5
- 🧪 xUnit
- 🔧 Moq

---

## 📂 Project Structure

```text
HelpDeskManagement
│
├── HelpDesk.Api
│   ├── Controllers
│   ├── Models
│   ├── Repository
│   ├── Migrations
│   └── Program.cs
│
├── HelpDesk.Mvc
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Views
│   ├── wwwroot
│   └── Program.cs
│
└── HelpDesk.Tests
    ├── Unit Tests
    └── Dependencies
```

---

## 📋 Prerequisites

Before running the project, install:

- ✔️ Visual Studio 2022
- ✔️ .NET SDK
- ✔️ SQL Server / LocalDB

---

## 🚀 Installation

### 1️⃣ Clone the repository

```bash
git clone https://github.com/Shreyb7/Help--Desk-Ticket-Management-System-IN26011418.git
```

### 2️⃣ Open the solution

Open:

```text
HelpDeskManagement.sln
```

using Visual Studio.

### 3️⃣ Configure the database

Update the connection string in:

```text
appsettings.json
```

Run:

```powershell
Update-Database
```

---

## ▶️ Running the Application

1. Open the solution in Visual Studio.
2. Select **Multiple Startup Projects**.
3. Start:
   - HelpDesk.Api
   - HelpDesk.Mvc
4. Run the application.

The API launches with **Swagger**, and the MVC application opens in your browser.

---

## 🧪 Testing

The solution includes unit tests using **xUnit** and **Moq**.

Run all tests from:

```text
Test → Run All Tests
```

---

## 🚀 Future Enhancements

- 🔐 User Authentication & Authorization
- 📧 Email Notifications

---

## 👨‍💻 Author

**Shreyas Borkar (IN26011418)**

