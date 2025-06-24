using System.Data;
using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(d => d.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");
        RuleFor(d => d.KiloCalories).GreaterThanOrEqualTo(0).WithMessage("Calories must be greater than or equal to 0");
    }
}
