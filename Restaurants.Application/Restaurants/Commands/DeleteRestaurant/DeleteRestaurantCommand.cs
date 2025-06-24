using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand(int restaurantId) : IRequest
{
    public int restaurantId { get; } = restaurantId;
}
