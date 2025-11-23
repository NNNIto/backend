// src/Foodstagram.Api/DI/ApiServiceCollectionExtensions.cs
using System.Reflection;
using AutoMapper;
using Foodstagram.Api.Mappings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using Foodstagram.Application; // Application‘w‚ÌDIŠg’£‚ª‚ ‚ê‚Î‚±‚±‚Å

namespace Foodstagram.Api.DI;

public static class ApiServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // MediatR (Application ‘w‚Ìƒnƒ“ƒhƒ‰‚ðƒXƒLƒƒƒ“)
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

        // Application, Infrastructure ‚Ö‚Ì DI Šg’£‚ª‚ ‚ê‚Î‚±‚±‚ÅŒÄ‚Ô‘z’è
        // services.AddApplication(configuration);
        // services.AddInfrastructure(configuration);

        return services;
    }
}
