using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantsRepository
    {
        private readonly RestaurantsDbContext _context;

        public RestaurantRepository(RestaurantsDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await _context.Restaurants
                .Include(r => r.Dishes)
                .ToListAsync();

            return restaurants;

        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return restaurant;
        }
    }
}
