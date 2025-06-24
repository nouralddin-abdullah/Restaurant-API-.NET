using MediatR;
using Microsoft.Extensions.Logging;
using Resuaurants.Domain.Exceptions;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

internal class DeleteAllDishesFromRestaurantQueryHandler(ILogger<DeleteAllDishesFromRestaurantQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository) : IRequestHandler<DeleteAllDishesFromRestaurantQuery>
{
    public async Task Handle(DeleteAllDishesFromRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Trying to delete all dishes from restaurant id {resaurantId}", request.restaurantId);
        var restaurant = await restaurantsRepository.GetOneAsync(request.restaurantId) ?? throw new NotFoundException("No restaurant was found with this id");
        await dishesRepository.DeleteAll(restaurant.Dishes);
    }
}
