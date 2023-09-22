namespace Logistics.Domain.Suppliers
{
    public interface ISupplierRepository
    {
        public void Add(Supplier supplier);
        public Task<Supplier?> GetById(Guid id);
        public Task<bool> SupplierExists(Guid id);
    }
}
