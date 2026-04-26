using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();

        Task<Restaurant?> GetRestaurantByIdAsync(int id);

        Task<int> CreateRestaurantAsync(Restaurant restaurant);
    }
}
