using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await restaurantsService.GetRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
    }
}
