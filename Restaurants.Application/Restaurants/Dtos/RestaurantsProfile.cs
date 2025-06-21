using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Resuaurants.Domain.Entities;
namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        //creating restaurant
        CreateMap<CreateRestaurantCommand, Resuaurants.Domain.Entities.Restaurants>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }
                ));


        //getting restaurant(s)
        CreateMap<Resuaurants.Domain.Entities.Restaurants, RestaurantDtos>()
            .ForMember(d => d.City, opt => opt.MapFrom( src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

        //updating Restaurant
        CreateMap<UpdateRestaurantCommand, Resuaurants.Domain.Entities.Restaurants>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
