using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public class DeleteAllDishesFromRestaurantQuery(int restaurantId) : IRequest
{
    public int restaurantId { get; set; } = restaurantId;
}
