// src/Foodstagram.Api/Config/ApiCorsConfig.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodstagram.Api.Config;

public static class ApiCorsConfig
{
    public const string PolicyName = "FoodstagramCors";

    public static IServiceCollection AddApiCors(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var origins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, builder =>
            {
                builder
                    .WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseApiCors(this IApplicationBuilder app)
    {
        return app.UseCors(PolicyName);
    }
}
