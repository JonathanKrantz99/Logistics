namespace Logistics.Api.DTOs
{
    public class SupplierStockItemDTO
    {
        public Guid WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
