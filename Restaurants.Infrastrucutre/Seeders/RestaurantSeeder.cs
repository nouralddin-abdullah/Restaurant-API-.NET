using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurants.Infrastrucutre.Persistence;
using Resuaurants.Domain.Entities;

namespace Restaurants.Infrastrucutre.Seeders
{


    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var resturants = GetRestaurants();
                    await dbContext.Restaurants.AddRangeAsync(resturants);
                    await dbContext.SaveChangesAsync();
                }
            }

        }

        private static List<Resuaurants.Domain.Entities.Restaurants> GetRestaurants()
        {
            var restaurants = new List<Resuaurants.Domain.Entities.Restaurants>
    {
        new()
        {
            Name = "KFC",
            Category = "Fast Food",
            Description =
                "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
            ContactEmail = "contact@kfc.com",
            HasDelivery = true,
            Dishes = [
            
                new()
                {
                    Name = "Nashville Hot Chicken",
                    Description = "Nashville Hot Chicken (10 pcs.)",
                    Price = 10.30M,
                },
                new()
                {
                    Name = "Chicken Nuggets",
                    Description = "Chicken Nuggets (5 pcs.)",
                    Price = 5.30M,
                },
            ],
            Address = new Address
            {
                City = "London",
                Street = "Cork St 5",
                PostalCode = "WC2N 5DU"
            }
        },
        new()
        {
            Name = "McDonald",
            Category = "Fast Food",
            Description =
                "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
            ContactEmail = "contact@mcdonald.com",
            HasDelivery = true,
            Address = new Address
            {
                City = "London",
                Street = "Boots 193",
                PostalCode = "W1F 8SR"
            }
        }
    };
            return restaurants;
        }

    }
}
