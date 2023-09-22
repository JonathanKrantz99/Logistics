using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Products.Commands.Update
{
    public record UpdateProductRequest
    {
        public UpdateProductRequest(string name)
        {
            Name = name;
        }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; }
    }
}
