using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SparkSaver.Application.Configuration;
using SparkSaver.Domain.Interfaces;
using SparkSaver.Domain.Interfaces.Clients;
using SparkSaver.Infrastructure.Database;
using SparkSaver.Infrastructure.Database.Interceptors;
using SparkSaver.Infrastructure.HttpClients.Telegram;

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

        // Http clients.

        services.AddHttpClient<ITelegramClient, TelegramClient>((sp, client) =>
        {
            var settings = sp.GetRequiredService<IOptions<TelegramSettings>>();

            client.BaseAddress = new Uri($"{settings.Value.ApiUrl}/{settings.Value.BotId}/", UriKind.Absolute);
        });

        return services;
    }
}
