using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Warehouses.Commands.AddStockItem
{
    public record AddStockItemRequest
    {
        public AddStockItemRequest(Guid ProductId, Guid SupplierId, int quantity) 
        {
            this.ProductId = ProductId;
            this.SupplierId = SupplierId;
            Quantity = quantity;
        }

        [Required]
        public Guid ProductId { get; }

        [Required]
        public Guid SupplierId { get; }

        [Required]
        public int Quantity { get; }
    }
}
