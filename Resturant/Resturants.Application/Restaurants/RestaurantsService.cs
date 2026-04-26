using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Repositories;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository,
        ILogger<RestaurantsService> logger,
        IMapper mapper

        ) : IRestaurantsService
    {
        public async Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto)
        {
            logger.LogInformation("Creating restaurant with name {Name}", createRestaurantDto.Name);
            var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
            var id = await restaurantsRepository.CreateRestaurantAsync(restaurant);
            return id;
        }

        public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
        {
            logger.LogInformation("Getting restaurant with id {Id}", id);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            //var restaurantDto =  RestaurantDto.FromEntity(restaurant);
            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
            return restaurantDto;
        }

        public async Task<IEnumerable<RestaurantDto?>> GetRestaurantsAsync()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            //var restaurantDto = restaurants.Select(RestaurantDto.FromEntity);
            var restaurantDto = mapper.Map<IEnumerable<RestaurantDto?>>(restaurants);
            return restaurantDto;

        }
    }
}
