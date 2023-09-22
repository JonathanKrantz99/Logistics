using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.RemoveStockItem
{
    public record RemoveStockItemRequest
    {
        public RemoveStockItemRequest(Guid productId, Guid supplierId, int quantity)
        {
            ProductId = productId;
            SupplierId = supplierId;
            Quantity = quantity;
        }

        [Required]
        public Guid ProductId { get; init; }

        [Required]
        public Guid SupplierId { get; init; }

        [Range(1, int.MaxValue - 1)]
        public int Quantity { get; init; }
    }
}
