using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace MultiShop.Order.Application.Services;

public static class ServiceRegistiration
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        // Add application services here
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
    }
}
