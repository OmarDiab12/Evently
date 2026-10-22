# Evently

[![build](https://github.com/OmarDiab12/Evently/actions/workflows/ci.yml/badge.svg)](https://github.com/OmarDiab12/Evently/actions/workflows/ci.yml)
![.NET 8](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-17-4169E1?logo=postgresql&logoColor=white)
![Status](https://img.shields.io/badge/status-in%20progress-orange)

An event management platform built as a **modular monolith** in .NET 8. Each business module is fully isolated with its own layers and database schema, so it can later be extracted into a separate service if needed.

## Architecture

```text
Evently.Api (host)
   │  registers modules
   ▼
Events module
 ├── Domain          entities, domain rules
 ├── Application     CQRS commands & queries (MediatR) + FluentValidation
 ├── Infrastructure  EF Core (PostgreSQL), Dapper for reads, migrations
 └── Presentation    minimal API endpoints
```

- **Module isolation:** each module exposes only its Presentation layer to the host
- **CQRS:** EF Core for writes, Dapper for fast reads
- **Database per module:** dedicated schema, snake_case naming conventions

## Implemented so far

- [x] Events module: create event, get event
- [x] PostgreSQL with EF Core migrations
- [x] Docker Compose (API + PostgreSQL)
- [ ] Users module
- [ ] Ticketing module
- [ ] Attendance module
- [ ] Cross-module integration events (outbox/inbox)

## Tech stack

.NET 8 · ASP.NET Core Minimal APIs · MediatR · FluentValidation · EF Core · Dapper · PostgreSQL · Docker Compose · Swagger

## Run locally

```bash
git clone https://github.com/OmarDiab12/Evently.git
cd Evently
docker compose up -d
```

## Author

**Omar Mohamed Diab**, Backend Software Engineer (.NET) · [LinkedIn](https://www.linkedin.com/in/omr-diyab/)
