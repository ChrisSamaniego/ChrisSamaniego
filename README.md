# School Portal (Blazor + API)

Minimal and responsive Blazor school portal with Student/Teacher/Administrator workflows.

## Projects

- **SchoolPortal** (this web app): Blazor UI and in-memory app services.
- **SchoolPortal.Data**: shared EF Core entity model + `SchoolPortalDbContext`.
- **SchoolPortal.Api**: minimal API endpoints for core portal objects (users, courses, tests, documents, messages, schedules, etc.).

## Tech stack

- Blazor Web App (interactive server components)
- ASP.NET Core Minimal API
- Entity Framework Core
- .NET 9 (`net9.0` target)

## Run web app

```bash
dotnet restore
dotnet run --project SchoolPortal.csproj
```

## Run API project

```bash
dotnet run --project SchoolPortal.Api/SchoolPortal.Api.csproj
```

Then open Swagger UI at the URL shown in terminal (typically `/swagger`).
