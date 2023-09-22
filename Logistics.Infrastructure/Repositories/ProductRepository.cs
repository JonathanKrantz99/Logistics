using Logistics.Domain.Products;
using Logistics.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Logistics.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product product)
        {
            _dbContext.Product.Add(product);
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _dbContext.Product.Include(x => x.ProductSuppliers)
                                   .Include(x => x.StockItems)
                                   .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ProductExists(Guid id)
        {
            return await _dbContext.Product.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ProductsSupplierExists(Guid supplierId)
        {
            return await _dbContext.Product.AnyAsync(x => x.ProductSuppliers.Any(x => x.SupplierId == supplierId));
        }

        public async Task<bool> ProductSupplierExists(Guid productId, Guid supplierId)
        {
            return await _dbContext.Product.AnyAsync(x => x.Id == productId && x.ProductSuppliers.Any(x => x.SupplierId == supplierId));
        }
    }
}
