using Logistics.Api.DTOs;
using Logistics.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Histories.Queries.GetAll
{
    public class GetAllHistoriesQueryHandler : IRequestHandler<GetAllHistoriesQuery, List<HistoryDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllHistoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<List<HistoryDTO>> IRequestHandler<GetAllHistoriesQuery, List<HistoryDTO>>.Handle(GetAllHistoriesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.History.Select(x => new HistoryDTO
            {
                SourceWarehouseId = x.SourceWarehouseId,
                TargetWarehouseId = x.TargetWarehouseId,
                ProductId = x.ProductId,
                Quantity = x.Quantity
            })
            .ToListAsync();
        }
    }
}
