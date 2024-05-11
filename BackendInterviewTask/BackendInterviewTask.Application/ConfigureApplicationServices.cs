using BackendInterviewTask.Application.Gateways.Repositories.Image;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendInterviewTask.Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
