using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Products;
using Logistics.Domain.Suppliers;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Remove
{
    internal class RemoveSupplierCommandHandler : IRequestHandler<RemoveSupplierCommand, Result<bool, HandlerError>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveSupplierCommandHandler(ISupplierRepository supplierRepository, IWarehouseRepository warehouseRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _warehouseRepository = warehouseRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetById(request.SupplierId);

            if (supplier is null)
            {
                return HandlerError.Create($"Supplier with id: {request.SupplierId} was not found.");
            }

            if (await _warehouseRepository.StockItemsExistBySupplier(request.SupplierId))
            {
                return HandlerError.Create($"Supplier with id: {request.SupplierId} can not be removed because one or more warehouses contains stock supplied by this supplier");
            }

            if (await _productRepository.ProductsSupplierExists(request.SupplierId))
            {
                return HandlerError.Create($"Supplier with id: {request.SupplierId} can not be removed because it is listed as a product supplier on one or more products");
            }

            supplier.RemoveSupplier();

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
