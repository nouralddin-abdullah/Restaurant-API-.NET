
using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastrucutre.Persistence;
using Resuaurants.Domain.Exceptions;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Infrastrucutre.Repositories;

internal class RestaurantsRepositories(RestaurantsDbContext dbContext) : IRestaurantsRepository
{

    public async Task<IEnumerable<Resuaurants.Domain.Entities.Restaurants>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();
        return restaurants;
    }

    public async Task<Resuaurants.Domain.Entities.Restaurants?> GetOneAsync(int restaurantId)
    {
        return await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(x => x.Id == restaurantId);
    }

    public async Task<int> CreateRestaurant(Resuaurants.Domain.Entities.Restaurants restaurantEntity)
    {
        await dbContext.Restaurants.AddAsync(restaurantEntity);
        await dbContext.SaveChangesAsync();
        return restaurantEntity.Id;

    }

    public async Task DeleteRestaurant(int restaurantId)
    {
        var restaurant = await dbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == restaurantId);
        if (restaurant is null)
        {
            throw new Resuaurants.Domain.Exceptions.NotFoundException("No restaurant was found");
        }
        dbContext.Restaurants.Remove(restaurant);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateRestaurant(Resuaurants.Domain.Entities.Restaurants updatedRestaurant)
    {
        await dbContext.SaveChangesAsync();
    }
}
