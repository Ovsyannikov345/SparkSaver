using SparkSaver.Domain.Interfaces;

namespace SparkSaver.Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<IApplicationDbContext>();

            context.ApplyMigrations();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "An error occurred while migrating the database.");

            throw;
        }

        return app;
    }
}
