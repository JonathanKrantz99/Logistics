using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Domain.Products
{
    public class ProductSupplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid SupplierId { get; private set; }

        internal ProductSupplier(Guid id, Guid productId, Guid supplierId)
        {
            Id = id;
            ProductId = productId;
            SupplierId = supplierId;
        }
    }
}
