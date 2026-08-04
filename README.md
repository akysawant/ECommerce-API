# 🛒 E-Commerce Web API (.NET 8)

A production-oriented **E-Commerce REST API** built using **ASP.NET Core 8** and **Entity Framework Core**. This project demonstrates modern backend development practices including authentication, validation, caching, middleware, API versioning, concurrency handling, and clean code principles.

The primary goal of this project is to strengthen backend development skills while implementing concepts commonly used in enterprise applications.

---

# 🚀 Tech Stack

* ASP.NET Core 8 Web API
* C#
* Entity Framework Core
* MySQL
* JWT Authentication
* FluentValidation
* Redis Cache
* In-Memory Cache
* Swagger / OpenAPI
* Dependency Injection
* Repository Pattern
* Global Exception Handling Middleware

---

# ✨ Features

## Authentication & Authorization

* JWT Authentication
* Protected APIs using Authorization
* Secure API endpoints

## Product Management

* Create Product
* Get All Products
* Get Product By Id
* Update Product
* Delete Product

## Category Management

* Complete CRUD Operations

## Validation

* FluentValidation for request validation
* Custom validation error responses

## Caching

* In-Memory Cache
* Redis Cache Integration

## Exception Handling

* Global Exception Middleware
* Standardized API responses
* Proper HTTP status codes

## API Enhancements

* API Versioning
* Async/Await
* DTO Pattern
* Repository Pattern
* Dependency Injection

## Entity Framework Core

* Code First Approach
* LINQ Queries
* Projection
* Tracking vs No Tracking
* IQueryable vs IEnumerable
* Optimistic Concurrency

---

# 📂 Project Structure

```
ECommerceAPI
│
├── Controllers
├── Services
├── Repositories
├── Interfaces
├── DTOs
├── Entities
├── Validators
├── Middleware
├── Authentication
├── Caching
├── Data
├── Migrations
├── Common
└── Program.cs
```

---

# 📚 Concepts Implemented

### ASP.NET Core

* RESTful API Development
* Dependency Injection
* Middleware
* Global Exception Handling
* API Versioning
* JWT Authentication
* Swagger Documentation
* Background Services
* Standard API Response

### Entity Framework Core

* Code First
* CRUD Operations
* LINQ
* Async Queries
* Tracking & No Tracking
* Optimistic Concurrency
* IQueryable vs IEnumerable
* Projection

### C#

* Async / Await
* Generics
* Dependency Injection
* Interfaces
* SOLID Principles (Basic)
* Repository Pattern

---

# ⚙️ Getting Started

## 1. Clone Repository

```bash
git clone https://github.com/akysawant/ECommerce-API.git
```

## 2. Navigate to Project

```bash
cd ECommerce-API
```

## 3. Configure Database

Update the connection string inside:

```
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ECommerceDb;User=root;Password=yourpassword;"
}
```

## 4. Apply Migrations

```bash
dotnet ef database update
```

## 5. Run Application

```bash
dotnet run
```

## 6. Open Swagger

```
https://localhost:5001/swagger
```

or

```
https://localhost:<port>/swagger
```

---

# 📖 API Modules

### Authentication

* Login
* Generate JWT Token

### Products

* Create Product
* Update Product
* Delete Product
* Get Product By Id
* Get All Products

### Categories

* Create Category
* Update Category
* Delete Category
* Get Category By Id
* Get All Categories

---

# 🗄 Database Entities

* Category
* Product

*(Additional modules such as Customer, Order, and Order Items can be added in future enhancements.)*

---

# 🛠 Design Patterns & Practices

* Repository Pattern
* DTO Pattern
* Dependency Injection
* Global Exception Handling
* Validation using FluentValidation
* Standard API Response
* Caching Strategy
* Separation of Concerns

---

# 📈 Current Learning Progress

The following concepts are currently being implemented to continuously improve the project:

* MediatR & CQRS
* Serilog
* Health Checks
* Rate Limiting
* Refresh Token Authentication
* Specification Pattern
* Clean Architecture

---

# 🎯 Purpose of This Project

This project was built to gain practical experience with modern ASP.NET Core backend development and to demonstrate skills in:

* Designing scalable REST APIs
* Writing clean and maintainable code
* Applying backend design patterns
* Working with Entity Framework Core
* Implementing authentication and authorization
* Improving API performance using caching
* Handling exceptions and validation effectively

---

# 🤝 Contributing

Suggestions and improvements are always welcome. Feel free to fork the repository, create a feature branch, and submit a pull request.

---

# 📄 License

This project is intended for learning and portfolio purposes.

---

# 👨‍💻 Author

**Akshay Sawant**

Backend Developer | ASP.NET Core | C# | Entity Framework Core | MySQL | Redis

If you found this project helpful, consider giving it a ⭐ on GitHub.
