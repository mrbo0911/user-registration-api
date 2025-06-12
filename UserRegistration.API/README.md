# .NET Core Registration & Migration API

This project provides backend APIs for a mobile app's registration and user migration flow.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- Swagger for API testing
- MediatR for CQRS pattern

## Project Structure
- `UserRegistration.API` – Main API project
	+ Controllers for handling HTTP requests
	+ Swagger configuration for API documentation
- `UserRegistration.Domain` – Domain models and interfaces
- `UserRegistration.Infrastructure` – Data access and migrations
	+ Entity Framework Core DbContext
	+ Migrations for database schema
- `UserRegistration.Application` – Application logic and MediatR handler

## Deliverable
- Source Code (as `.zip`)
- README included
