using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

try
{
    // ----------------------------
    // Setup Serilog early
    // ----------------------------
    var logPath = "/tmp/logs";
    if (!Directory.Exists(logPath))
    {
        Directory.CreateDirectory(logPath);
    }

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File(Path.Combine(logPath, "app.log"), rollingInterval: RollingInterval.Day)
        .CreateLogger();

    Log.Information("Starting SynergyApplicationFrameworkApi...");

    // ----------------------------
    // Create builder and load config
    // ----------------------------
    var builder = WebApplication.CreateBuilder(args);

    // Add Serilog
    builder.Host.UseSerilog();

    // Load configuration from appsettings.json
    builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    // Validate paths from AppSettings
    var appSettings = builder.Configuration.GetSection("AppSettings");
    var errorPath = appSettings["Synergy.Core.ErrorPath"];
    if (!Directory.Exists(errorPath))
    {
        Log.Warning("ErrorPath '{Path}' does not exist. Creating...", errorPath);
        Directory.CreateDirectory(errorPath);
    }

    var ghostScriptPath = appSettings["GhostScriptPath"];
    if (!File.Exists(ghostScriptPath))
    {
        Log.Warning("GhostScript executable not found at '{Path}'", ghostScriptPath);
    }

    // ----------------------------
    // Add services
    // ----------------------------
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Example: add AutoMapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Add EF DbContext here (pseudo example)
    // builder.Services.AddDbContext<PathwayDbContext>(options =>
    //     options.UseSqlServer(builder.Configuration.GetConnectionString("Pathway")));

    // ----------------------------
    // Build the app
    // ----------------------------
    var app = builder.Build();

    // ----------------------------
    // Bind to all interfaces on port 8080 (port 80 requires root on Linux)
    // ----------------------------
    app.Urls.Clear();
    app.Urls.Add("http://+:8080");

    // Enable Swagger if in Development
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Optional: comment out HTTPS redirection for HTTP testing
    // app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapControllers();

    Log.Information("SynergyApplicationFrameworkApi started successfully.");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed!");
    throw;
}
finally
{
    Log.CloseAndFlush();
}