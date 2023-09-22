using Logistics.Api.DTOs;
using Logistics.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Products.Queries.GetAll
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllProductsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Product.Where(x => x.Removed == false)
                                           .Select(x => new ProductDTO { Id = x.Id, Name = x.Name, Suppliers = x.ProductSuppliers.Select(x => x.SupplierId).ToList() })
                                           .ToListAsync();
        }
    }
}
