using Logistics.Api.DTOs;
using Logistics.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Warehouses.Queries.GetAll
{
    internal class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, List<WarehouseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllWarehousesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WarehouseDTO>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            if (request.ProductSearch != null)
            {
                return await _dbContext.Warehouse.Where(x => x.Removed == false)
                                                 .Select(x => new WarehouseDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Adress = $"{x.Address.Street} {x.Address.StreetNumber}, {x.Address.PostalCode}, {x.Address.City}",
                    StockItems = x.StockItems.Where(x => x.ProductId == request.ProductSearch).Select(x => new StockItemDTO { ProductId = x.ProductId, SupplierId = x.SupplierId, Quantity = x.Quantity }).ToList()
                })
                .Where(x => x.StockItems.Any())
                .ToListAsync();
            }

            return await _dbContext.Warehouse.Where(x => x.Removed == false)
                                             .Select(x => new WarehouseDTO
            {
                Id = x.Id,
                Name = x.Name,
                Adress = $"{x.Address.Street} {x.Address.StreetNumber}, {x.Address.PostalCode}, {x.Address.City}",
                StockItems = x.StockItems.Select(x => new StockItemDTO { ProductId = x.ProductId, SupplierId = x.SupplierId, Quantity = x.Quantity }).ToList()
            })
            .ToListAsync();
        }

    }
}
