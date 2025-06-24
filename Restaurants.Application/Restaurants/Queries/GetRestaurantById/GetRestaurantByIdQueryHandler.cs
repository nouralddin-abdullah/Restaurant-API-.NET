using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Resuaurants.Domain.Entities;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

internal class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDtos>
{
    public async Task<RestaurantDtos> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a restaurant by id: {request.Id}", request.Id);
        var restaurant = await restaurantsRepository.GetOneAsync(request.Id)
            ?? throw new Resuaurants.Domain.Exceptions.NotFoundException("No restaurant was found");

        var restaurantDto = mapper.Map<RestaurantDtos>(restaurant);
        return restaurantDto;

    }
}
