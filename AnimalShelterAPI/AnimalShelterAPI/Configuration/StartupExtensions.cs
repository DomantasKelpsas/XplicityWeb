using AnimalShelterAPI.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelterAPI.Configurations
{
    public static class StartupExtensions
    {
        public static void SetUpAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
