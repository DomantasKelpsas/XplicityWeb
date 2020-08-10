using AnimalShelterAPI.Models;
using AnimalShelterAPI.Infrastructure.Repositories;
using AnimalShelterAPI.Services;
using AnimalShelterAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelterAPI.Configurations
{
    public static class DepedencyInjectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IRepository<Animal>, AnimalRepository>();
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IAnimalService, AnimalService>();
        }
    }
}
