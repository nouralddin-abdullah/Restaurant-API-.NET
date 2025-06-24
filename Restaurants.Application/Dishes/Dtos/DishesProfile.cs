
using AutoMapper;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Resuaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        //Creating a dish
        CreateMap<CreateDishCommand, Dish>();
        CreateMap<Dish, DishDtos>();

    }
}
