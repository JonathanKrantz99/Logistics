using Logistics.Domain.Suppliers;
using Logistics.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Supplier supplier)
        {
            _dbContext.Supplier.Add(supplier);
        }

        public async Task<Supplier?> GetById(Guid id)
        {
            return await _dbContext.Supplier.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SupplierExists(Guid id)
        {
            return await _dbContext.Supplier.AnyAsync(x => x.Id == id);
        }
    }
}
