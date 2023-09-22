using Logistics.Api.Common;
using Logistics.Domain.Warehouses;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.MoveStockItems
{
    internal class MoveStockItemsCommandHandler : IRequestHandler<MoveStockItemsCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MoveStockItemsCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(MoveStockItemsCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            var newWarehouse = await _warehouseRepository.GetById(request.NewWarehouseId);

            if (newWarehouse is null)
            {
                return HandlerError.Create($"Target warehouse with id: {request.NewWarehouseId} was not found.");
            }

            if (!warehouse.StockItemExists(request.ProductId, request.SupplierId))
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} does not contain product with id: {request.ProductId} from supplier with id: {request.SupplierId}.");
            }

            if (!warehouse.StockItemQuantityExists(request.ProductId, request.SupplierId, request.Quantity))
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} does not have enough quantity of product with id: {request.ProductId} from supplier with id: {request.SupplierId}.");
            }

            warehouse.MoveStockItemQuantity(request.ProductId, request.SupplierId, request.Quantity, newWarehouse);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
