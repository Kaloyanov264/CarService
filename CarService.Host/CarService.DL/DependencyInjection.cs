using CarService.DL.Interfaces;
using CarService.DL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            // Register your data layer services here
            services
                .AddSingleton<ICarRepository, CarLocalRepository>()
                .AddSingleton<ICustomerRepository, CustomerLocalRepository>();

            return services;
        }
    }
}
