using BlackArm.Application.Contracts;
using BlackArm.Application.LoggerService;
using BlackArm.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination"));
        });
    }
    
    public static void ConfigureRepositoryManager(this IServiceCollection services)=>
    services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<ArmWrestlersDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"), b => 
            b.MigrationsAssembly("BlackArm.API")));
    
    
    public static void ConfigureLoggerService(this IServiceCollection services) =>
    services.AddSingleton<ILoggerManager, LoggerManager>();
    
    
    public static void ConfigureResponseCaching(this IServiceCollection services) =>
    services.AddResponseCaching();

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
        services.AddHttpCacheHeaders(
            (expirationOpt) =>
            {
                expirationOpt.MaxAge = 65;
                expirationOpt.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
            },
            (validationOpt) =>
            {
                validationOpt.MustRevalidate = true;
            });
}