using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Common
{
    public record Address
    {
        [Required]
        public string City { get; init; }

        [Required]
        public string PostalCode { get; init; }

        [Required]
        public string Street { get; init; }

        [Required]
        public string StreetNumber { get; init; }

        public Address(string city, string postalCode, string street, string streetNumber)
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
        }
    }
}
