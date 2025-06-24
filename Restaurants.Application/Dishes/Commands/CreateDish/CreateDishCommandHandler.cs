using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resuaurants.Domain.Entities;
using Resuaurants.Domain.Exceptions;
using Resuaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IRestaurantsRepository restaurantsRepository,IDishesRepository dishesRepository, IMapper mapper) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish {@DishRequest}", request);
        //check if the restaurant exist
        var restaurant = await restaurantsRepository.GetOneAsync(request.RestaurantsId);
        if (restaurant == null)
            throw new NotFoundException("There's no restaurant was found with that id");
        var dishEntity = mapper.Map<Dish>(request);
        await dishesRepository.Create(dishEntity);
        return dishEntity.Id;
    }
}
