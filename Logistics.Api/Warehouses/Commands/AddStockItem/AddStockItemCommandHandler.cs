using Logistics.Api.Common;
using Logistics.Domain.Products;
using Logistics.Domain.Warehouses;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.AddStockItem
{
    internal class AddStockItemCommandHandler : IRequestHandler<AddStockItemCommand, Result<bool, HandlerError>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddStockItemCommandHandler(IWarehouseRepository warehouseRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(AddStockItemCommand request, CancellationToken cancellationToken)
        {
            var warehouse = await _warehouseRepository.GetById(request.WarehouseId);

            if (warehouse is null)
            {
                return HandlerError.Create($"Warehouse with id: {request.WarehouseId} was not found.");
            }

            if (!await _productRepository.ProductExists(request.ProductId))
            {
                return HandlerError.Create($"Product with id: {request.ProductId} was not found.");
            }

            var productSupplierExists = await _productRepository.ProductSupplierExists(request.ProductId, request.SupplierId);

            if (!productSupplierExists)
            {
                return HandlerError.Create($"Product with id: {request.ProductId} can not be supplied by supplier with id: {request.SupplierId}.");
            }

            warehouse.AddStockItem(request.ProductId, request.SupplierId, request.quantity);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
