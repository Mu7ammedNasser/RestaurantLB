using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();

            // this line is for AutoMapper, it will scan the assembly for any classes that inherit from AutoMapper.Profile and register them
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
