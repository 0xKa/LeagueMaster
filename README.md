# LeagueMaster

A comprehensive **RESTful Web API** for managing football leagues, teams, players, coaches, and matches. Built with **.NET 9** and following **Clean Architecture** principles with a focus on security, scalability, and maintainability.

## ✨ Features

### Core Functionality

- **League Management** - Create and manage football leagues with seasons
- **Team Management** - Handle team information, stadiums, and league associations
- **Player Management** - Manage player profiles, positions, and team assignments
- **Coach Management** - Track coaching staff and team associations
- **Match Management** - Schedule and record match results between teams

### Security & Authentication

- **JWT Authentication** - Secure token-based authentication system
- **Role-Based Authorization** - User and Admin roles with different permissions
- **Refresh Token Support** - Automatic token renewal for seamless user experience
- **Password Hashing** - Secure password storage using ASP.NET Core Identity

### Technical Features

- **Clean Architecture** - Separation of concerns across Domain, Application, Infrastructure, and API layers
- **Entity Framework Core** - Code-first approach with SQL Server integration
- **AutoMapper** - Automatic object-to-object mapping between entities and DTOs
- **Audit Trail** - Automatic tracking of creation and modification timestamps
- **API Documentation** - Interactive Swagger/OpenAPI documentation with Scalar UI

## 🛠️ Tech Stack

- **.NET 9** - Latest .NET framework
- **C# 13** - Modern C# language features
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Primary database
- **JWT Bearer Authentication** - Security implementation
- **AutoMapper** - Object mapping
- **Swagger/OpenAPI** - API documentation
- **Scalar** - Enhanced API documentation UI

## 🏗️ Architecture

The solution follows **Clean Architecture** principles with clear separation of concerns:

LeagueMaster.sln
├─ LeagueMaster.Domain/ # Core business entities and enums
│ ├─ Entities/ # League, Team, Player, Coach, Match, User
│ ├─ Enums/ # PlayerPosition, UserRole
│ └─ BaseDomainObject.cs # Base entity with audit fields
├─ LeagueMaster.Application/ # Business logic and use cases
│ ├─ DTOs/ # Data transfer objects
│ ├─ Interfaces/ # Service and repository abstractions
│ ├─ Services/ # Business logic implementation
│ └─ Mappings/ # AutoMapper profiles
├─ LeagueMaster.Infrastructure/ # Data access and external concerns
│ ├─ Persistence/ # DbContext and configurations
│ ├─ Repositories/ # Data access implementations
│ └─ Migrations/ # EF Core migrations
└─ LeagueMaster.API/ # HTTP layer and configuration
├─ Controllers/ # API endpoints
├─ Program.cs # Application startup
└─ appsettings.json # Configuration
