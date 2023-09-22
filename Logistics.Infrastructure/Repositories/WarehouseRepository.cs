using Logistics.Domain.Products;
using Logistics.Domain.Warehouses;
using Logistics.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WarehouseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Warehouse warehouse)
        {
            _dbContext.Warehouse.Add(warehouse);
        }

        public async Task<Warehouse?> GetById(Guid id)
        {
            return await _dbContext.Warehouse.Include(x => x.StockItems)
                                             .Include(x => x.HistoryMoved)
                                             .Include(x => x.HistoryRecieved)
                                             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> StockItemsExistByProduct(Guid productId)
        {
            return await _dbContext.Warehouse.AnyAsync(x => x.StockItems.Any(x => x.ProductId == productId));
        }

        public async Task<bool> StockItemsExistBySupplier(Guid supplierId)
        {
            return await _dbContext.Warehouse.AnyAsync(x => x.StockItems.Any(x => x.SupplierId == supplierId));
        }
    }
}
