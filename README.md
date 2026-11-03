# Dalil Academy LMS

Dalil Academy LMS is a learning management system API designed to manage academic operations in an online academy. The project is built with ASP.NET Core and uses Entity Framework Core with PostgreSQL for persistence. It supports the main entities of a training platform, including students, instructors, courses, and enrollments.

The application exposes REST API endpoints for creating, reading, updating, and deleting records, while using DTOs, validation, and service/repository layers to keep business logic organized and maintainable.

## Project overview

This solution follows a layered architecture:

- API layer: exposes the endpoints to clients and configures Swagger
- Core layer: holds entities, DTOs, repository contracts, service contracts, and validators
- Infrastructure layer: handles database access, repository implementations, and EF Core configuration

## Solution structure

- `Dalilacademy.slnx` — the Visual Studio solution file for the project
- `Dalilacademy.API/` — ASP.NET Core Web API project
- `Dalilacademy .Core/` — domain logic, DTOs, and abstractions
- `Dalilacademy.infra/` — data access and persistence implementation

## API project files

### `Dalilacademy.API/Program.cs`
Configures the ASP.NET Core application, registers dependency injections, configures Swagger, adds the database context, enables FluentValidation, and maps the controllers.

### `Dalilacademy.API/appsettings.json`
Contains the application configuration, including the PostgreSQL connection string and logging settings.

### `Dalilacademy.API/Controllers/`
This folder is intended to hold the API controllers for the different modules such as Course, Student, Instructor, and Enrollment.

### `Dalilacademy.API/Middekware/`
Contains custom middleware, including the global exception handler used to centralize error handling.

## Core project files

### `Dalilacademy .Core/Entities/`
Contains the main domain models, such as:
- `Course`
- `Student`
- `Instructor`
- `Enrollment`

These classes represent the business entities used by the system.

### `Dalilacademy .Core/DTOs/`
Includes request and response models used by the API, such as create/update DTOs and response DTOs. These help separate the database model from the external API contract.

### `Dalilacademy .Core/Repository/`
Contains repository interfaces for each entity, defining the data-access contract the application depends on.

### `Dalilacademy .Core/Service/`
Defines service interfaces for the business logic layer, separating contract definitions from implementation.

### `Dalilacademy .Core/Validdator/`
Contains FluentValidation validators for create and update requests, ensuring data validity before persistence.

### `Dalilacademy .Core/Mappings/`
Contains mapping logic used to transform between entities and DTOs.

### `Dalilacademy .Core/Exciptions/`
Stores custom exception classes used to standardize application errors.

## Infrastructure project files

### `Dalilacademy.infra/Data/`
Contains the EF Core database context (`AppDbContext`) and database configuration. It also seeds some default records for testing during development.

### `Dalilacademy.infra/Repository/`
Implements repository logic for courses, students, instructors, and enrollments. These classes interact with the database through EF Core and expose methods such as create, update, delete, fetch by ID, and pagination.

### `Dalilacademy.infra/Service/`
Contains business service implementations that use the repositories and validate operations before interacting with the data layer.

### `Dalilacademy.infra/Migrations/`
Stores the EF Core migration history used to evolve the database schema over time.

## Main features

- Course management
- Student management
- Instructor management
- Enrollment tracking
- Validation using FluentValidation
- API documentation with Swagger
- PostgreSQL integration with Entity Framework Core
- Repository and service architecture for clean separation of concerns

## Typical workflow

1. A client sends an HTTP request to the API.
2. The controller receives the request and passes it to the service layer.
3. The service implements the business logic and uses repository interfaces.
4. The repository interacts with the database through `AppDbContext`.
5. The response is mapped back to DTOs and returned to the client.

## Notes

The project includes some naming inconsistencies in folder and class names such as `Exciptions`, `Middekware`, and `Validdator`, which appear to be due to early development naming choices. These do not affect the overall architecture, but they are worth knowing when working in the codebase.

## Technology stack

- C#
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- FluentValidation
- Swagger/OpenAPI

## Getting started

1. Open the solution file `Dalilacademy.slnx` in Visual Studio.
2. Make sure PostgreSQL is running and the connection string in `appsettings.json` matches your local database configuration.
3. Restore NuGet packages.
4. Run the project using the API startup profile.
5. Open the Swagger UI in the browser to test the endpoints.

This README gives a general overview of the project structure and the purpose of each major folder so that new developers can quickly understand the solution.
