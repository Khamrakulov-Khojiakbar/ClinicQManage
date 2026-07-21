using Mapster.Adapters;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mapster;

namespace AvangardQManagement.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);

        return services;
    }
}