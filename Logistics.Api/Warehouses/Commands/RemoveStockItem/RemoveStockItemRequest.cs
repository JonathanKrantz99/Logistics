using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.RemoveStockItem
{
    public record RemoveStockItemRequest
    {
        public RemoveStockItemRequest(Guid ProductId, Guid SupplierId, int Quantity)
        {
            this.ProductId = ProductId;
            this.SupplierId = SupplierId;
            this.Quantity = Quantity;
        }

        [Required]
        public Guid ProductId { get; }

        [Required]
        public Guid SupplierId { get; }

        [Required]
        public int Quantity { get; }
    }
}
