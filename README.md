# Project Name: ctms-api

## Description
A basic CTMS API project demonstrating the use of ASP.NET Core to create a backend for clinical trial management systems. It includes examples of implementing RESTful services, handling cross-origin requests, and configuring entities.

## Technologies Used
- **ASP.NET Core**: For creating robust APIs.
- **CORS**: Configured to allow cross-origin requests in development environments.

## Setup
1. Clone the repository.
2. Ensure you have .NET Core SDK installed.
3. Navigate to the repository directory and run `dotnet restore` to install dependencies.
4. Start the server with `dotnet run`.

## Features
- Configuration of CORS policy to facilitate development testing across different domains.
- Structured organization into entities, DTOs, and endpoints for clear separation of concerns.
- [Additional features based on more detailed exploration of the repository.]

## Project Structure
- **Data/**: Contains seed data and initialization scripts.
- **Dtos/**: Data transfer objects to manage data exchange.
- **Endpoints/**: RESTful endpoints for API access.
- **Entities/**: Core business logic models.
- **Properties/**: Configuration settings.
- **Program.cs**: Entry point of the API.
- Configuration files such as `appsettings.json` and `Api.csproj`.
