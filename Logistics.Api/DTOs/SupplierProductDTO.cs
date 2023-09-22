namespace Logistics.Api.DTOs
{
    public class SupplierProductDTO
    {
        public Guid Id { get; set; }
        public List<ValuePair> Warehouses { get; set; }
    }

    public class ValuePair
    {
        public Guid WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
