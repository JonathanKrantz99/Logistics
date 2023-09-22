using Logistics.Domain.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Domain.Warehouses
{
    public class StockItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public Guid WarehouseId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid SupplierId { get; private set; }
        public int Quantity { get; private set; }

        internal StockItem(Guid id, Guid warehouseId, Guid productId, Guid supplierId, int quantity)
        {
            Id = id;
            WarehouseId = warehouseId;
            ProductId = productId;
            SupplierId = supplierId;
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
