using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Mordos.API.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

// Configure Azure Table Storage
builder.Services.AddSingleton<TableServiceClient>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    
    // Get the connection string from configuration
    // In local development, this will use the storage emulator
    // In production, this will use the actual Azure Storage account
    var connectionString = configuration.GetConnectionString("tables") 
                          ?? configuration["AzureWebJobsStorage"]
                          ?? "UseDevelopmentStorage=true";
    
    return new TableServiceClient(connectionString);
});

// Register business services
builder.Services.AddScoped<IBicepTemplateService, BicepTemplateService>();
builder.Services.AddScoped<IDeploymentService, DeploymentService>();

builder.Build().Run();
