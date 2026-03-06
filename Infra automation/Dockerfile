# Use a multi-stage build to reduce image size
# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
# This ensures that the restore step is only re-run when the csproj file changes
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create a non-root user and group
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Create the logs directory for Serilog
RUN mkdir -p /app/logs

# Set environment variables for application
ENV ASPNETCORE_URLS="http://+:80;https://+:443"
ENV ASPNETCORE_ENVIRONMENT="Production"
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages

# Expose ports 80 and 443
EXPOSE 80
EXPOSE 443

# Health check for application
HEALTHCHECK --interval=30s --timeout=10s --retries=3 CMD curl -f http://localhost:80/health || exit 1

# Run the application 
ENTRYPOINT ["dotnet", "SynergyApplicationFrameworkApi.dll"]

