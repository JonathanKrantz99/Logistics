using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveAllStockItemsByProduct
{
    internal class RemoveAllStockItemsByProductCommandHandler : IRequestHandler<RemoveAllStockItemsByProductCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveAllStockItemsByProductCommandHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveAllStockItemsByProductCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            warehouse.RemoveAllStockItemsByProduct(request.ProductId);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
