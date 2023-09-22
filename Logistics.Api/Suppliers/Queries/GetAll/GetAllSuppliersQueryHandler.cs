using Logistics.Api.DTOs;
using Logistics.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Suppliers.Queries.GetAll
{
    internal class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<SupplierDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllSuppliersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SupplierDTO>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _dbContext.Supplier.Where(x => x.Removed == false)
                                                     .Select(x => new SupplierDTO { Id = x.Id, Name = x.Name })
                                                     .ToListAsync();

            var stockItems = await _dbContext.StockItem.ToListAsync();

            foreach (var supplierDTO in suppliers)
            {
                supplierDTO.Products = stockItems.Where(x => x.SupplierId == supplierDTO.Id)
                                                 .Select(x => new SupplierStockItemDTO { WarehouseId = x.WarehouseId, ProductId = x.ProductId, Quantity = x.Quantity }).ToList();
            }

            return suppliers;
        }
    }
}
