using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool IsOpen { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public List<DishDto>? Dishes { get; set; } = [] ;


        //public static RestaurantDto? FromEntity(Restaurant? restaurant)
        //{
        //    if (restaurant == null) return null;
        //    return new RestaurantDto
        //    {
        //        Id = restaurant.Id,
        //        Name = restaurant.Name,
        //        Description = restaurant.Description,
        //        Category = restaurant.Category,
        //        IsOpen = restaurant.IsOpen,
        //        HasDelivery = restaurant.HasDelivery,
        //        City = restaurant.Address?.City ?? string.Empty,
        //        Street = restaurant.Address?.Street ?? string.Empty,
        //        PostalCode = restaurant.Address?.PostalCode ?? string.Empty,
        //        Dishes = restaurant.Dishes?.Select(DishDto.FromEntity).ToList() ?? new List<DishDto>()
        //    };
        //}
    }
}
