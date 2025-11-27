using System.Reflection;
using Foodstagram.Api.Mappings;
using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Infrastructure.Identity;
using Foodstagram.Infrastructure.Persistence;
using Foodstagram.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodstagram.Api.DI;

public static class ApiServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var applicationAssembly = Assembly.Load("Foodstagram.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(cfg => cfg.AddProfile<ApiMappingProfile>());

        services.AddHttpContextAccessor();

        var cs = configuration.GetConnectionString("Default");
        services.AddDbContext<FoodstagramDbContext>(opt =>
            opt.UseSqlServer(cs));

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IStoryRepository, StoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();
        services.AddScoped<IShareRepository, ShareRepository>();

        services.AddScoped<ICurrentUserService, AuthUserProvider>();

        return services;
    }
}
