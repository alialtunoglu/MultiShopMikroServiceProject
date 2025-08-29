using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD

=======
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca
namespace MultiShop.Order.Application.Services;

public static class ServiceRegistiration
{
<<<<<<< HEAD
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
    }
    

=======
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        // Add application services here
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
    }
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca
}
