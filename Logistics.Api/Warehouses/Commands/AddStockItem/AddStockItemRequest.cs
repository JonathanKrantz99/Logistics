using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.AddStockItem
{
    public record AddStockItemRequest
    {
        public AddStockItemRequest(Guid productId, Guid supplierId, int quantity) 
        {
            ProductId = productId;
            SupplierId = supplierId;
            Quantity = quantity;
        }

        [Required]
        public Guid ProductId { get; }

        [Required]
        public Guid SupplierId { get; }

        [Range(1, int.MaxValue - 1)]
        public int Quantity { get; }
    }
}
