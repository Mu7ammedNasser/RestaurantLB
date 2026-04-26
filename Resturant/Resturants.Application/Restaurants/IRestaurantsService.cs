using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto?>> GetRestaurantsAsync();

        Task<RestaurantDto?> GetRestaurantByIdAsync(int id);
        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto);
    }
}