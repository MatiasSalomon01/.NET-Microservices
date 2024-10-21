namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseWebApiServices(this WebApplication app)
    {
        return app;
    }
}
