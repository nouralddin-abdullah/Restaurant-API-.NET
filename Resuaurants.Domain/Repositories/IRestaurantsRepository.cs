namespace Resuaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Resuaurants.Domain.Entities.Restaurants>> GetAllAsync();
    Task<Resuaurants.Domain.Entities.Restaurants?> GetOneAsync(int restaurantId);
    Task<int> CreateRestaurant(Resuaurants.Domain.Entities.Restaurants restaurantEntity);
    Task<bool> DeleteRestaurant(int restaurantId);
    Task UpdateRestaurant(Resuaurants.Domain.Entities.Restaurants updatedRestaurant);
}