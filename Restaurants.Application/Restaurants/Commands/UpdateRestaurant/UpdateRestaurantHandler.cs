using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resuaurants.Domain.Entities;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantHandler(ILogger<UpdateRestaurantHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {request.restaurantId}, with new data {@restaruant}", request.restaurantId, request);
        var restaurantTargeted = await restaurantsRepository.GetOneAsync(request.restaurantId) ?? throw new Resuaurants.Domain.Exceptions.NotFoundException($"No restaurant with {request.restaurantId}" +
            $" was found");
        mapper.Map(request, restaurantTargeted);
        await restaurantsRepository.UpdateRestaurant(restaurantTargeted);
    }
}
