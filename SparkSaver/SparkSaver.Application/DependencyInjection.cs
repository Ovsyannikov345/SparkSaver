using Microsoft.Extensions.DependencyInjection;
using SparkSaver.Application.Services;

namespace SparkSaver.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ILinkService, LinkService>();

        return services;
    }
}
