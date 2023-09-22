using Logistics.Api.Common;
using Logistics.Api.DTOs;
using Logistics.Api.Services.Adresses;
using Logistics.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouses
{
    internal class GetDistanceBetweenWarehousesQueryHandler : IRequestHandler<GetDistanceBetweenWarehousesQuery, Result<DistanceDTO, HandlerError>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AdressService _adressService;

        public GetDistanceBetweenWarehousesQueryHandler(ApplicationDbContext dbContext, AdressService adressService)
        {
            _dbContext = dbContext;
            _adressService = adressService;
        }
        public async Task<Result<DistanceDTO, HandlerError>> Handle(GetDistanceBetweenWarehousesQuery request, CancellationToken cancellationToken)
        {
            var sourceWarehouseAddress = await _dbContext.Warehouse.Where(x => x.Id == request.SourceWarehouseId)
                                                                   .Select(x => new Common.Address
            (
                x.Address.City,
                x.Address.PostalCode,
                x.Address.Street,
                x.Address.StreetNumber
            ))
            .FirstOrDefaultAsync();

            if (sourceWarehouseAddress is null)
            {
                return HandlerError.Create($"The source warehouse with id: {request.SourceWarehouseId} was not found.");
            }

            var targetWarehouseAddress = await _dbContext.Warehouse.Where(x => x.Id == request.TargetWarehouseId)
                                                                   .Select(x => new Common.Address
            (
                x.Address.City,
                x.Address.PostalCode,
                x.Address.Street,
                x.Address.StreetNumber
            ))
            .FirstOrDefaultAsync();

            if (targetWarehouseAddress is null)
            {
                return HandlerError.Create($"The target warehouse with id: {request.TargetWarehouseId} was not found.");
            }

            var distanceBetween = await _adressService.GetDistance(sourceWarehouseAddress, targetWarehouseAddress);

            return new DistanceDTO
            {
                Unit = "km",
                Distance = distanceBetween
            };
        }
    }
}
