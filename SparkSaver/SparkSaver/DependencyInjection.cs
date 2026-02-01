namespace SparkSaver.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
