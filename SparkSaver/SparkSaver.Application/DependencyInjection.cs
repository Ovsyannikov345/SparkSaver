using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SparkSaver.Application.Configuration;
using SparkSaver.Application.Services;

namespace SparkSaver.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration.

        services.Configure<TelegramSettings>(
            configuration.GetSection(TelegramSettings.SectionName));

        // Services.

        services.AddScoped<ILinkService, LinkService>();

        return services;
    }
}
