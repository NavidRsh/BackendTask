using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Infra.Persistence.EfCoreSqlite.Persistence.Repositories;
using BackendInterviewTask.Infra.Persistence.EfCoreSQlite.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BackendInterviewTask.Infra.Persistence.EfCoreSqlite;

public static class ConfigureServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(); 
        
        services.AddScoped<IImageQueryRepository, ImageQueryRepository>();

        return services;
    }
}
