using Logistics.Api.Common;
using Logistics.Domain.Products;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Products.Commands.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<bool, HandlerError>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool, HandlerError>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newproduct = Product.Create(request.Name);

            _productRepository.Add(newproduct);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
