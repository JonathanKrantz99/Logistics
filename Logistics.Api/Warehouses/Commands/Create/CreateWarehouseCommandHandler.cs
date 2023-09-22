using Logistics.Api.Common;
using Logistics.Api.Services.Adresses;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.Create
{
    internal class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdressService _adressService;

        public CreateWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, AdressService adressService)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _adressService = adressService;
        }
        public async Task<Result<bool, HandlerError>> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            bool isRealAddress = await _adressService.IsRealAdress(request.WarehouseAddress);

            if (!isRealAddress)
            {
                return HandlerError.Create($"Invalid address: {request.WarehouseAddress.Street} {request.WarehouseAddress.StreetNumber}, " +
                                           $"{request.WarehouseAddress.City}, {request.WarehouseAddress.PostalCode}");
            }


            var address = Domain.Warehouses.Address.Create(request.WarehouseAddress.City, request.WarehouseAddress.PostalCode, 
                                         request.WarehouseAddress.Street, request.WarehouseAddress.StreetNumber);

            var newWarehouse = Warehouse.Create(request.Name, address);

            _warehouseRepository.Add(newWarehouse);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
