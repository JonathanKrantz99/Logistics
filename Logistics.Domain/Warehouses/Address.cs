namespace Logistics.Domain.Warehouses
{
    public record Address
    {
        public string City { get; init; }
        public string PostalCode { get; init; }
        public string Street { get; init; }
        public string StreetNumber { get; init; }

        private Address(string city, string postalCode, string street, string streetNumber) 
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
        }


        public static Address Create(string city, string postalCode, string street, string streetNumber)
        {
            return new Address(city, postalCode, street, streetNumber);
        }
    }
}
