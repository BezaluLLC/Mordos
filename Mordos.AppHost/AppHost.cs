var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage")
                     .RunAsEmulator();
var tables = storage.AddTables("tables");

builder.AddAzureFunctionsProject<Projects.Mordos_API>("mordos-api")
    .WithHostStorage(storage)
    .WithReference(tables);

builder.Build().Run();
