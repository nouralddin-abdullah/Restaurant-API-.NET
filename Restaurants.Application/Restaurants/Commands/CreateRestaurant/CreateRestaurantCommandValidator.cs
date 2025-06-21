using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3,100)
            .WithMessage("Restaurant should has a name, minimum 3 chars and maximum 100");

        RuleFor(dto => dto.ContactEmail)
            .NotEmpty().EmailAddress().WithMessage("Should be a valid email address");

        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Should be a valid category");
    }

}
