using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Products;
using MediatR;

namespace Logistics.Api.Products.Commands.RemoveProductSupplier
{
    internal class RemoveProductSupplierCommandHandler : IRequestHandler<RemoveProductSupplierCommand, Result<bool, HandlerError>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductSupplierCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveProductSupplierCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.ProductId);

            if (product is null)
            {
                return HandlerError.Create($"Product with id: {request.ProductId} was not found.");
            }

            if (!product.SupplierExists(request.SupplierId))
            {
                return HandlerError.Create($"Product with id: {request.ProductId} does not have a supplier with id: {request.SupplierId}.");
            }

            product.RemoveSupplier(request.SupplierId);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
