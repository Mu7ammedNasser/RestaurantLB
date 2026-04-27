using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
    {
        //[StringLength(maximumLength: 100 , MinimumLength = 3)]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        //[Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = default!;
        public bool IsOpen { get; set; }
        public bool HasDelivery { get; set; }

        //[EmailAddress(ErrorMessage = "Please Provide a valid Email Address")]
        public string? ContactEmail { get; set; }
        //[Phone(ErrorMessage = "Please Provide a valid Phone Number")]
        public string? ContactNumber { get; set; }

        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;

        //[RegularExpression(@"\d{2}-\d{3}")]
        public string PostalCode { get; set; } = default!;
    }
}
