using MediatR;
using Logistics.Api.Common;
using Microsoft.EntityFrameworkCore;
using Logistics.Infrastructure.Db;
using Logistics.Api.Services.Adresses;
using Logistics.Api.DTOs;

namespace Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouseAndCustomer
{
    internal class GetDistanceBetweenWarehouseAndCustomerQueryHandler : IRequestHandler<GetDistanceBetweenWarehouseAndCustomerQuery, Result<DistanceDTO, HandlerError>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AdressService _adressService;

        public GetDistanceBetweenWarehouseAndCustomerQueryHandler(ApplicationDbContext dbContext, AdressService adressService)
        {
            _dbContext = dbContext;
            _adressService = adressService;
        }
        public async Task<Result<DistanceDTO, HandlerError>> Handle(GetDistanceBetweenWarehouseAndCustomerQuery request, CancellationToken cancellationToken)
        {
            var warehouseAddress = await _dbContext.Warehouse.Where(x => x.Id == request.WarehouseId)
                                                                   .Select(x => new Address
            (
                x.Address.City,
                x.Address.PostalCode,
                x.Address.Street,
                x.Address.StreetNumber
            ))
            .FirstOrDefaultAsync();

            if (warehouseAddress is null)
            {
                return HandlerError.Create($"The source warehouse with id: {request.WarehouseId} was not found.");
            }

            bool isRealAddress = await _adressService.IsRealAdress(request.Address);

            if (!isRealAddress)
            {
                return HandlerError.Create($"Invalid address: {request.Address.Street} {request.Address.StreetNumber}, " +
                                           $"{request.Address.City}, {request.Address.PostalCode}");
            }

            var distanceBetween = await _adressService.GetDistance(warehouseAddress, request.Address);

            return new DistanceDTO
            {
                Unit = "km",
                Distance = distanceBetween
            };
        }
    }
}
