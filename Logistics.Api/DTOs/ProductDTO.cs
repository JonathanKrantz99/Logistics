namespace Logistics.Api.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Guid> Suppliers { get; set; }
    }
}
