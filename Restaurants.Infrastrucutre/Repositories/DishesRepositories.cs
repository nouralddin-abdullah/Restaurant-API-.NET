using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastrucutre.Persistence;
using Resuaurants.Domain.Entities;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Infrastrucutre.Repositories;

internal class DishesRepositories(RestaurantsDbContext dbContext) : IDishesRepository
{
    public async Task<int> Create(Dish dish)
    {
        dbContext.Dishes.Add(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task DeleteAll(IEnumerable<Dish> dishes)
    {
        dbContext.Dishes.RemoveRange(dishes);
        await dbContext.SaveChangesAsync();
    }
}
