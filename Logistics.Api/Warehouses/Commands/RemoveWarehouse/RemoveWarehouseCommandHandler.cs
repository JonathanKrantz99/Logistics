using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveWarehouse
{
    internal class RemoveWarehouseCommandHandler : IRequestHandler<RemoveWarehouseCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWarehouseCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveWarehouseCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            if (warehouse.HasStockItems())
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} can not be removed because it contains stock.");
            }

            warehouse.RemoveWarehouse();

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
