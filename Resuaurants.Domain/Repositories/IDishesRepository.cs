using Resuaurants.Domain.Entities;

namespace Resuaurants.Domain.Repositories;

public interface IDishesRepository
{
    public Task<int> Create(Dish dish);
    public Task DeleteAll(IEnumerable<Dish> dishes);
}
