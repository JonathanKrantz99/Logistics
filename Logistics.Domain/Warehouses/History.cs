using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Domain.Warehouses
{
    public class History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public Guid SourceWarehouseId { get; private set; }
        public Guid TargetWarehouseId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid SupplierId { get; private set; }
        public int Quantity { get; private set; }

        internal History(Guid id, Guid sourceWarehouseId, Guid targetWarehouseId, Guid productId, Guid supplierId, int quantity)
        {
            Id = id;
            SourceWarehouseId = sourceWarehouseId;
            TargetWarehouseId = targetWarehouseId;
            ProductId = productId;
            SupplierId = supplierId;
            Quantity = quantity;
        }
    }
}
