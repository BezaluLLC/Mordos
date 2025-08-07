using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Mordos.API.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Register business services
builder.Services.AddHttpClient()
                .AddScoped<IBicepTemplateService, BicepTemplateService>()
                .AddScoped<IDeploymentService, DeploymentService>();

builder.Build().Run();