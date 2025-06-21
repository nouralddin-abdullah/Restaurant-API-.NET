using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDtos>>
{

}
