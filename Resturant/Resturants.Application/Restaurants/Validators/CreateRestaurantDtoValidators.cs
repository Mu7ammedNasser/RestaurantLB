using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidators : AbstractValidator<CreateRestaurantDto>
    {
        private readonly List<string> validCategories = [ "Italian", "Chinese", "Mexican", "Indian", "Fast Food" ];
        public CreateRestaurantDtoValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.ContactEmail)
                .EmailAddress().WithMessage("Please provide a valid email address.");

            RuleFor(x => x.PostalCode)
                .Matches(@"\d{2}-\d{3}").WithMessage("Postal code must be in the format XX-XXX.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.")
                .Must(category => validCategories.Contains(category))
                .WithMessage($"Category must be one of the following: {string.Join(", ", validCategories)}");
        }
    }
}
