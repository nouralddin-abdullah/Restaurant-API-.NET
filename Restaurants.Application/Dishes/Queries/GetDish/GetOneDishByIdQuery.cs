using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDish;

public class GetOneDishByIdQuery(int restaurantId, int dishId) : IRequest<DishDtos>
{
    public int restaurantId { get; set; } = restaurantId;
    public int dishId { get; set; } = dishId;
}
