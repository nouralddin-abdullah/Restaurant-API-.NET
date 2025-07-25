﻿using Restaurants.Application.Dishes.Dtos;
using Resuaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDtos
{
    public int Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public string? Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDtos> Dishes { get; set; } = [];

}
