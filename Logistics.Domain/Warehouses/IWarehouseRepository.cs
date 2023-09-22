namespace Logistics.Domain.Warehouses
{
    public interface IWarehouseRepository
    {
        public void Add(Warehouse warehouse);
        public Task<Warehouse?> GetById(Guid id);

        public Task<bool> StockItemsExistBySupplier(Guid supplierId);
        public Task<bool> StockItemsExistByProduct(Guid productId);
    }
}
