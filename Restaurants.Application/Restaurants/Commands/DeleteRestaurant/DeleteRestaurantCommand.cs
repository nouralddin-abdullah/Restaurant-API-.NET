using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand(int restaurantId) : IRequest<bool>
{
    public int restaurantId { get; } = restaurantId;
}
