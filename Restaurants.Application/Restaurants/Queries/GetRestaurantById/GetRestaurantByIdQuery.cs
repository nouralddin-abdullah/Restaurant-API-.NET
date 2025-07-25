﻿using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDtos>
{
    public int Id { get; } = id;
}
