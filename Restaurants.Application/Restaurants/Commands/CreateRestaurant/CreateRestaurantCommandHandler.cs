using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommand> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Creating Restaurant with {@restaurant}", request);
        var restaurantEntity = mapper.Map<Resuaurants.Domain.Entities.Restaurants>(request);
        int Id = await restaurantsRepository.CreateRestaurant(restaurantEntity);
        return Id;
    }
}
