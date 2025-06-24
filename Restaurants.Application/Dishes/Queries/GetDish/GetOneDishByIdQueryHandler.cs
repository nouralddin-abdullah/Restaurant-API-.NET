using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Resuaurants.Domain.Exceptions;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDish;

internal class GetOneDishByIdQueryHandler(ILogger<GetOneDishByIdQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetOneDishByIdQuery, DishDtos>
{
    public async Task<DishDtos> Handle(GetOneDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dish with id: {dishId} for restaurant id: {restaurantId}", request.dishId, request.restaurantId);
        var restaurant = await restaurantsRepository.GetOneAsync(request.restaurantId) ?? throw new NotFoundException("No restaurant was found with that id");
        var dishFromRestaurant = restaurant.Dishes.FirstOrDefault(d => d.Id == request.dishId) ?? throw new NotFoundException("No dish with that id was found in the restaurant");
        var dish = mapper.Map<DishDtos>(dishFromRestaurant);
        return dish;
    }
}
