using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Suppliers.Commands.Update
{
    public record UpdateSupplierRequest
    {
        public UpdateSupplierRequest(string name)
        {
            Name = name;
        }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Name { get; }
    }
}
