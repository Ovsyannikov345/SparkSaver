using SparkSaver.Application;
using SparkSaver.Infrastructure;
using SparkSaver.Presentation;
using SparkSaver.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services
    .RegisterPresentationServices()
    .RegisterApplicationServices(config)
    .RegisterInfrastructureServices(config);

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
