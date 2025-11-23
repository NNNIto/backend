// src/Foodstagram.Api/DI/ApiServiceCollectionExtensions.cs
using System.Reflection;
using AutoMapper;
using Foodstagram.Api.Mappings;
using MediatR;
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
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // AutoMapper
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<ApiMappingProfile>();
        });

        return services;
    }
}
