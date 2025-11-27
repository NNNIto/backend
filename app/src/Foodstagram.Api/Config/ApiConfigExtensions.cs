
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodstagram.Api.Config;

public static class ApiConfigExtensions
{
    public static IServiceCollection AddApiConfigs(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddApiCors(configuration)
            .AddApiSwagger(configuration)
            .AddApiAuthentication(configuration);

        return services;
    }
}
