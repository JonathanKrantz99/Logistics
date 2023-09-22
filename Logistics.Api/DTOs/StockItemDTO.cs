namespace Logistics.Api.DTOs
{
    public class StockItemDTO
    {
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public int Quantity { get; set; }
    }
}
