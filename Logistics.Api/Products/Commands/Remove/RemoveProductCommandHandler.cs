using Logistics.Api.Common;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Products;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Products.Commands.Remove
{
    internal class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Result<bool, HandlerError>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IProductRepository productRepository, IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.ProductId);

            if (product is null)
            {
                return HandlerError.Create($"Product with id: {request.ProductId} was not found.");
            }

            if (await _warehouseRepository.StockItemsExistByProduct(request.ProductId))
            {
                return HandlerError.Create($"Product with id: {request.ProductId} can not be removed because one or more warehouses contains stock with this product");
            }

            product.RemoveProduct();

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
