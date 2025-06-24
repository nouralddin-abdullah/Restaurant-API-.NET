using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Resuaurants.Domain.Exceptions;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
    internal class GetAllDishesforRestaurantQueryHandler(ILogger<GetAllDishesforRestaurantQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDtos>>
    {
        public async Task<IEnumerable<DishDtos>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all dishes data for restaurant id: {restaurantId}", request.restaurantId);
            var restaurant = await restaurantsRepository.GetOneAsync(request.restaurantId);
            if (restaurant == null)
                throw new NotFoundException("No restaurant found with that id");
            var dishesMapped = mapper.Map<IEnumerable<DishDtos>>(restaurant.Dishes);
            return dishesMapped;
        }
    }
}
