using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
    {
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }
        //public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // this is to configure the owned entity type for the address property of
            // the restaurant entity, this is important for the value object pattern,
            // owned entity means that the address is owned by the restaurant and it
            // cannot exist without the restaurant, and it will be stored in the same
            // table as the restaurant.

            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne(d => d.Restaurant)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
