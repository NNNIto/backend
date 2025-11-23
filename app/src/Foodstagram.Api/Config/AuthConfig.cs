// src/Foodstagram.Api/Config/AuthConfig.cs
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodstagram.Api.Config;

public static class AuthConfig
{
    public static IServiceCollection AddApiAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetSection("Authentication:Jwt");
        var authority = section["Authority"];
        var audience = section["Audience"];

        if (!string.IsNullOrWhiteSpace(authority) && !string.IsNullOrWhiteSpace(audience))
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = authority;
                    options.Audience = audience;
                    options.RequireHttpsMetadata = true;
                });
        }

        return services;
    }
}
