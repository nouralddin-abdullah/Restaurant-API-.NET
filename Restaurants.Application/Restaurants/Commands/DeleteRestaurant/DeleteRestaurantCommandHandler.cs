using MediatR;
using Microsoft.Extensions.Logging;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id: {restaurantId}", request.restaurantId);
        await restaurantsRepository.DeleteRestaurant(request.restaurantId);
    }
}
