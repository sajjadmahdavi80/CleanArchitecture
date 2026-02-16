# CleanArchitecture
A base Clean Architecture template built with .NET 10, implementing JWT authentication, Repository Pattern, and Unit of Work. Designed as a starting point for scalable backend projects with clear separation of concerns.
for backend applications.

Key characteristics:

Clear separation between Domain, Application, Infrastructure, and API

JWT-based authentication implemented in Infrastructure

Repository Pattern with Unit of Work abstraction

Application layer free of framework and infrastructure dependencies

EF Core isolated inside Infrastructure

Ready for extension with CQRS, validation, logging, and testing

Included layers:

Domain: Entities and core business rules

Application: Use cases, interfaces, and DTOs

Infrastructure: Data access, JWT implementation, repositories

API: Controllers / endpoints and request handling

Purpose:

This project is not a complete solution, but a clean starting point to avoid common architectural mistakes when building .NET backend systems.
