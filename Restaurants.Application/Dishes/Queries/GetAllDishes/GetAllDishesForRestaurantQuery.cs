using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDtos>>
    {
        public int restaurantId { get; set; } = restaurantId;
    }
}
