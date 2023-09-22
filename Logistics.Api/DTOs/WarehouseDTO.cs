namespace Logistics.Api.DTOs
{
    public class WarehouseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<StockItemDTO> StockItems { get; set; }
    }
}
