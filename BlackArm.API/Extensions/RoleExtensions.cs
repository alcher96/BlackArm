using BlackArm.Application.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BlackArm.API.Extensions;

public static class RoleExtensions
{
    public static async Task CreateRoles(this IServiceProvider serviceProvider, ILoggerManager logger)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
           // logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            var roles = configuration.GetSection("Roles").Get<string[]>();

            foreach (var role in roles)
            {
                try
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        logger.LogInfo($"Created role: {role}");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex +$"Error creating role {role}");
                }
            }
        }
    }
}