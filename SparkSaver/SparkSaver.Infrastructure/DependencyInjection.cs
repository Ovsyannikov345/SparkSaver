using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SparkSaver.Domain.Interfaces;
using SparkSaver.Infrastructure.Database;
using SparkSaver.Infrastructure.Database.Interceptors;

namespace SparkSaver.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database.

        services.AddSingleton<UpdateTimestampsInterceptor>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"))
                   .AddInterceptors(sp.GetRequiredService<UpdateTimestampsInterceptor>());
        });

        return services;
    }
}
