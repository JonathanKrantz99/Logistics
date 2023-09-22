using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Products.Commands.Create
{
    public record CreateProductRequest
    {
        public CreateProductRequest(string name)
        {
            Name = name;
        }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; }
    }
}
