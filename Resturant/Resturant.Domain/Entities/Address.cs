namespace Resturants.Domain.Entities
{
    public class Address
    {
        // no need to add identity for address because it just will be used to encapsulate the address details
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
    }
}
