using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveAllStockItems
{
    internal class RemoveAllStockItemsCommandHandler : IRequestHandler<RemoveAllStockItemsCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAllStockItemsCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveAllStockItemsCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            warehouse.RemoveAllStockItems();

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
