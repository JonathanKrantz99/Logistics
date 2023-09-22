namespace Logistics.Api.DTOs
{
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<SupplierStockItemDTO> Products { get; set; }
    }
}
