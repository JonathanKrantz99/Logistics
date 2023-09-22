using Logistics.Api.Common;
using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.Update
{
    public record UpdateWarehouseRequest
    {
        public UpdateWarehouseRequest(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; }

        [Required]
        public Address Address { get; }
    }
}
