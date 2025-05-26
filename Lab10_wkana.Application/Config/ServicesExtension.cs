using Lab10_wkana.Application.Intefaces;
using Lab10_wkana.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lab10_wkana.Application.Config;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<IResponseService, ResponseService>();
        services.AddScoped<IRoleService, RoleService>();
        
        return services;
    }
}