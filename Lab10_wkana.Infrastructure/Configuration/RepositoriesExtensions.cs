using Lab10_wkana.Domain.Interfaces.Base;
using Lab10_wkana.Infrastructure.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab10_wkana.Infrastructure.Configuration;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}