namespace Logistics.Domain.Products
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public Task<Product?> GetById(Guid id);
        public Task<bool> ProductExists(Guid id);
        public Task<bool> ProductSupplierExists(Guid productId, Guid supplierId);
        public Task<bool> ProductsSupplierExists(Guid supplierId);
    }
}
