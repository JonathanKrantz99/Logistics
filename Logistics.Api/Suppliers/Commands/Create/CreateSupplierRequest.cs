using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Suppliers.Commands.Create
{
    public record CreateSupplierRequest
    {
        public CreateSupplierRequest(string name)
        {
            Name = name;
        }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; }
    }
}
