using Logistics.Api.Common;
using Logistics.Domain.Products;
using Logistics.Domain.Suppliers;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Products.Commands.AddSupplier
{
    internal class AddProductSupplierCommandHandler : IRequestHandler<AddProductSupplierCommand, Result<bool, HandlerError>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductSupplierCommandHandler(IProductRepository productRepository, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(AddProductSupplierCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.ProductId);

            if (product is null)
            {
                return HandlerError.Create($"Product with id: {request.ProductId} was not found.");
            }

            if (!await _supplierRepository.SupplierExists(request.SupplierId))
            {
                return HandlerError.Create($"Supplier with id: {request.SupplierId} was not found.");
            }

            if (product.SupplierExists(request.SupplierId))
            {
                return HandlerError.Create($"Product with id: {request.ProductId} already has supplier with id: {request.SupplierId}.");
            }

            product.AddSupplier(request.SupplierId);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
