namespace Logistics.Api.DTOs
{
    public class HistoryDTO
    {
        public Guid SourceWarehouseId { get; set; }
        public Guid TargetWarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
