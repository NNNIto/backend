using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Infrastructure.Identity;
using Foodstagram.Infrastructure.Persistence;
using Foodstagram.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodstagram.Infrastructure.Config;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        var conn = config.GetConnectionString("Default");

        services.AddDbContext<FoodstagramDbContext>(options =>
        {
                // Use SQL Server provider (SQL Server package is referenced in app.csproj).
                // If you want to use MySQL, switch package references accordingly.
                options.UseSqlServer(conn);
        });

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStoryRepository, StoryRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUserService, AuthUserProvider>();

        return services;
    }
}
