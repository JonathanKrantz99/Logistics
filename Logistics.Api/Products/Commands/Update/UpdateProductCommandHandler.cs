using Logistics.Api.Common;
using Logistics.Domain.Products;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Products.Commands.Update
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<bool, HandlerError>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.ProductId);

            if (product is null)
            {
                return HandlerError.Create($"Product with id: {request.ProductId} was not found.");
            }

            product.UpdateInformation(request.Name);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
