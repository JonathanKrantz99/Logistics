using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.MoveStockItems
{
    public record MoveStockItemsRequest
    {
        public MoveStockItemsRequest(Guid targetWarehouseId, Guid productId, Guid supplierId, int quantity)
        {
            this.TargetWarehouseId = targetWarehouseId;
            this.ProductId = productId;
            this.SupplierId = supplierId;
            this.Quantity = quantity;
        }

        [Required]
        public Guid TargetWarehouseId { get; }

        [Required]
        public Guid ProductId { get; }

        [Required]
        public Guid SupplierId { get; }

        [Required]
        public int Quantity { get; }
    }
}
