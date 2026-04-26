using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;

namespace Restaurant.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region add services to the container
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplicationServices();
            #endregion

            var app = builder.Build();

                var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantsDbContext>();
                await dbContext.Database.MigrateAsync();
                var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

                await seeder.Seed();
            
            

            #region Configure the HTTP request pipeline.

            // this check is to make sure that the open api is only available in development environment and not in production environment
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            // this UseHttpsRedirection is to redirect all the http requests to https requests, this is important for security reasons,
            // and it is recommended to use https in production environment
            app.UseHttpsRedirection();


            app.UseAuthorization();

            // this MapControllers is to map the controllers to the endpoints, this is important for the routing of the application,
            // and it is recommended to use attribute routing in the controllers
            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
