# Synergy Application Framework API

This is a modernized .NET 8 Web API application migrated from WCF services.

## Quick Start

### Prerequisites
- .NET 8 SDK
- SQL Server or SQL Server LocalDB
- Visual Studio 2022 or VS Code

### Getting Started

1. **Restore packages**:
   ```bash
   dotnet restore
   ```

2. **Update connection string** in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Your-Connection-String-Here"
   }
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Access Swagger UI**: Navigate to `https://localhost:7000` (or the port shown in console)

## NuGet Packages Included

### Core Framework
- **Microsoft.AspNetCore.App** (8.0) - ASP.NET Core framework
- **Microsoft.NET.Sdk.Web** - Web SDK for building web applications

### Database & ORM
- **Microsoft.EntityFrameworkCore** (8.0.0) - Entity Framework Core ORM
- **Microsoft.EntityFrameworkCore.SqlServer** (8.0.0) - SQL Server provider
- **Microsoft.EntityFrameworkCore.Tools** (8.0.0) - EF Core migrations tools

### Object Mapping
- **AutoMapper** (12.0.1) - Object-to-object mapping
- **AutoMapper.Extensions.Microsoft.DependencyInjection** (12.0.1) - DI integration

### Logging
- **Serilog.AspNetCore** (8.0.0) - Structured logging
- **Serilog.Sinks.File** (5.0.0) - File logging sink
- **Serilog.Sinks.Console** (5.0.0) - Console logging sink

### API Documentation
- **Swashbuckle.AspNetCore** (6.5.0) - OpenAPI/Swagger generation
- **Swashbuckle.AspNetCore.Annotations** (6.5.0) - Enhanced Swagger annotations

### JSON Processing
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson** (8.0.0) - Newtonsoft.Json integration
- **Newtonsoft.Json** (13.0.3) - JSON serialization

### Validation
- **FluentValidation.AspNetCore** (11.3.0) - Fluent validation framework

### Health Checks
- **Microsoft.Extensions.Diagnostics.HealthChecks** (8.0.0) - Health check framework

### Development Tools
- **Microsoft.AspNetCore.OpenApi** (8.0.0) - OpenAPI integration
- **Microsoft.VisualStudio.Azure.Containers.Tools.Targets** (1.19.5) - Container support

## Project Structure

```
SynergyApplicationFrameworkApi/
  Controllers/           # API Controllers
  Models/               # Data models and DTOs
    DTOs/            # Data Transfer Objects
    Entities/        # Database entities
  Services/            # Business logic services
    Interfaces/      # Service contracts
    Implementations/ # Service implementations
  Application/         # Application layer
    Mapping/         # AutoMapper profiles
    Validators/      # FluentValidation validators
  Infrastructure/      # Infrastructure concerns
    Data/           # DbContext and repositories
    Configuration/  # Configuration extensions
  Middleware/         # Custom middleware
  wwwroot/           # Static files
  appsettings.json   # Configuration
  Program.cs         # Application entry point
  Dockerfile         # Docker configuration
  README.md          # This file
```

## Migration Notes

### From WCF Services
- WCF service contracts -> Web API controllers
- DataContracts -> DTOs with JSON serialization
- ServiceModel attributes removed
- Enterprise Library -> Serilog for logging
- Unity Container -> Built-in DI container

### Database Migration
- Entity Framework 6.x -> Entity Framework Core 8.0
- Connection strings updated for EF Core format
- Migrations folder will contain EF Core migrations

### Configuration Migration
- `web.config` -> `appsettings.json`
- Unity configuration -> built-in DI in `Program.cs`
- Custom configuration sections migrated to strongly-typed options

## Development Guidelines

### Adding New Services
1. Create interface in `Services/Interfaces/`
2. Implement service in `Services/Implementations/`
3. Register in `Program.cs` DI container
4. Create controller in `Controllers/`

### Adding New Models
1. Create entity in `Models/Entities/`
2. Create DTO in `Models/DTOs/`
3. Create mapping profile in `Application/Mapping/`
4. Add validator in `Application/Validators/`

### Database Changes
1. Update entity models
2. Run: `dotnet ef migrations add MigrationName`
3. Run: `dotnet ef database update`

## Performance Considerations

- Connection pooling enabled
- Response compression configured
- Health checks included at `/health`
- Structured logging with Serilog
- Docker support included

## Troubleshooting

### Common Issues
1. **Connection String**: Update in `appsettings.json`
2. **Port Conflicts**: Check `launchSettings.json`
3. **Missing Packages**: Run `dotnet restore`
4. **Database Issues**: Check connection string and run migrations

### Logs Location
- Console output during development
- File logs in `logs/` directory (created automatically)

## Deployment

### Local Development
```bash
dotnet run
```

### Docker
```bash
docker build -t synergy-api .
docker run -p 8080:8080 synergy-api
```

### Production Considerations
- Update connection strings
- Configure CORS for production origins
- Set up proper SSL certificates
- Configure logging levels
- Set up health check monitoring

---

**Migration completed successfully!**
