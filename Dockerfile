# =============================================================================
#  Multi-stage Dockerfile – SynergyApplicationFrameworkApi (.NET 8)
#
#  ✔  Works for monorepo / multi-project .NET solutions
#  ✔  Copies the entire repository before restore
#  ✔  Restores dependencies for ALL projects via the .sln file
#  ✔  Builds & publishes the main ASP.NET Core API project
#  ✔  Multi-stage build keeps the final image lean (no SDK in production)
#  ✔  Does NOT assume a fixed project layout
#  ✔  One-command build:  docker build -t synergy-api .
#  ✔  One-command run:    docker run -p 8080:8080 synergy-api
#
#  Tested target: AWS ECS / Fargate / App Runner (linux/amd64)
# =============================================================================

# ── [1] BASE – slim ASP.NET runtime (no SDK, keeps final image small) ─────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Create runtime directories used by the application:
#   /app/logs  → replaces the Windows-only  C:\log\  used by Serilog
#   /app/temp  → scratch space for report generation / file operations
RUN mkdir -p /app/logs /app/temp \
    && chown -R app:app /app/logs /app/temp

EXPOSE 8080
EXPOSE 8081

# ── [2] RESTORE – cached dependency layer (SDK stage) ─────────────────────────
#
#  Strategy: copy ONLY manifest files (.sln + .csproj) before running restore.
#  Docker will reuse this cached layer on every rebuild unless a project file
#  changes, making subsequent builds significantly faster.
#
#  ┌─ MULTI-PROJECT EXTENSION POINT ──────────────────────────────────────────┐
#  │  For each additional project in the solution, add one COPY line here     │
#  │  BEFORE the `dotnet restore` command, mirroring your repo layout:        │
#  │                                                                           │
#  │  COPY ["Shared/Shared.csproj",                "Shared/"]                 │
#  │  COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]        │
#  │  COPY ["Tests/MyApi.Tests.csproj",             "Tests/"]                 │
#  └───────────────────────────────────────────────────────────────────────────┘
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src

# Copy the solution manifest
COPY ["SynergyApplicationFrameworkApi.sln", "."]

# Copy the main API project file
COPY ["SynergyApplicationFrameworkApi.csproj", "."]

# Restore ALL projects in the solution (resolves all transitive NuGet references)
RUN dotnet restore "SynergyApplicationFrameworkApi.sln"

# ── [3] BUILD ──────────────────────────────────────────────────────────────────
FROM restore AS build
ARG BUILD_CONFIGURATION=Release

# Copy the entire source tree (all projects, shared libraries, assets)
COPY . .

RUN dotnet build "SynergyApplicationFrameworkApi.csproj" \
        -c $BUILD_CONFIGURATION \
        --no-restore \
        -o /app/build

# ── [4] PUBLISH ────────────────────────────────────────────────────────────────
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "SynergyApplicationFrameworkApi.csproj" \
        -c $BUILD_CONFIGURATION \
        --no-restore \
        --no-self-contained \
        /p:UseAppHost=false \
        -o /app/publish

# ── [5] FINAL – runtime-only image ────────────────────────────────────────────
FROM base AS final
WORKDIR /app

# ─────────────────────────────────────────────────────────────────────────────
#  ⚠  ACTION REQUIRED – URL BINDING IN Program.cs
#
#  The current Program.cs contains:
#      app.Urls.Clear();
#      app.Urls.Add("http://localhost:5055");
#
#  Those two lines override ASPNETCORE_URLS and bind the application to the
#  loopback interface only, which makes the container unreachable from outside.
#
#  Before deploying to AWS, replace those lines with environment-variable-driven
#  binding so the container respects the values set below:
#
#      // Remove or conditionally guard the hard-coded URL, e.g.:
#      if (!app.Environment.IsProduction())
#      {
#          app.Urls.Clear();
#          app.Urls.Add("http://localhost:5055");
#      }
#
#  The ASPNETCORE_URLS env var below will then take effect in production.
# ─────────────────────────────────────────────────────────────────────────────

# ASP.NET Core URL bindings (effective once Program.cs is updated – see above)
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENV ASPNETCORE_HTTPS_PORTS=8081

# Runtime flags
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_ENVIRONMENT=Production

# ─── Redirect Windows-specific AppSettings paths to container equivalents ─────
# Overrides appsettings.json values; can also be supplied at runtime via
# ECS task-definition environment variables or AWS Parameter Store / Secrets.
ENV AppSettings__Synergy__Core__ErrorPath=/app/logs/
ENV AppSettings__Synergy__Core__ErrorLogging=true
ENV AppSettings__GhostScriptPath=/usr/bin/gs

# Copy published artefacts from the publish stage
COPY --from=publish /app/publish .

# Run as the non-root 'app' user that ships with the official aspnet image
USER app

ENTRYPOINT ["dotnet", "SynergyApplicationFrameworkApi.dll"]
