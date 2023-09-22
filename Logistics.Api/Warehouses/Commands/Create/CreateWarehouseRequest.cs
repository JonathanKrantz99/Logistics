using System.ComponentModel.DataAnnotations;
using Logistics.Api.Common;

namespace Logistics.Api.Warehouses.Commands.Create
{
    public record CreateWarehouseRequest
    {
        public CreateWarehouseRequest(string name, Address address) 
        {
            Name = name;
            Address = address;
        }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; init; }

        [Required]
        public Address Address { get; init; }
    }
}
