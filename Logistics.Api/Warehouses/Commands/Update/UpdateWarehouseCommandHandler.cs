using Logistics.Api.Common;
using Logistics.Api.Services.Adresses;
using Logistics.Domain.Warehouses;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.Update
{
    internal class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdressService _adressService;

        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, AdressService adressService)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _adressService = adressService;
        }

        public async Task<Result<bool, HandlerError>> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            bool isRealAddress = await _adressService.IsRealAdress(request.WarehouseAddress);

            if (!isRealAddress)
            {
                return HandlerError.Create($"Invalid address: {request.WarehouseAddress.Street} {request.WarehouseAddress.StreetNumber}, " +
                                           $"{request.WarehouseAddress.City}, {request.WarehouseAddress.PostalCode}");
            }

            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            var address = Domain.Warehouses.Address.Create(request.WarehouseAddress.City, request.WarehouseAddress.PostalCode,
                                         request.WarehouseAddress.Street, request.WarehouseAddress.StreetNumber);

            warehouse.UpdateInformation(request.Name, address);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
