# 🎮 Gamestore

A full-stack web application for managing and browsing digital games. Built with **.NET + Angular**, following **Clean Architecture** principles.

---

## 🏗 Project Structure

```
src/
├── API/
│ └── Gamestore.API # ASP.NET Core Web API entry point
├── Core/
│ ├── Gamestore.Domain # Entities, Enums, ValueObjects
│ └── Gamestore.Application # Use cases, CQRS (Commands/Queries)
├── Infrastructure/
│ ├── Gamestore.Identity # Identity/Auth logic (ASP.NET Core Identity)
│ ├── Gamestore.Infrastructure # External services, logging, cache, email, etc.
│ └── Gamestore.Persistence # EF Core DbContext + Repositories
└── UI/
└── Gamestore.UI # Angular 17+ frontend (standalone components + Tailwind)
```
---

## 🖥 Technologies Used

### Backend (.NET)
- ASP.NET Core Web API
- Clean Architecture (DDD)
- Entity Framework Core
- MediatR (CQRS)
- ASP.NET Core Identity

### Frontend (Angular)
- Angular 17 Standalone
- Tailwind CSS for styling
- Component-based UI (GameCard, Navbar, etc.)

---

## 🚧 Features

- 🕹 Game listing with dynamic routing
- 🛒 Shopping cart (planned)
- 🔒 User login & registration (planned)
- 🧩 Scalable architecture using Clean Architecture principles

---

## 🐳 Future Plans

- 🐳 Docker support (multi-project) (planned)
- 🧠 Redis for distributed caching (planned)
- 📦 Modular deployment (planned)
- 🏁 GitHub Actions CI/CD (planned)

---

## 🚀 Getting Started

### Backend
```bash
cd src/API/Gamestore.API
dotnet run

### Frontend
cd src/UI/Gamestore.UI
npm install
ng serve