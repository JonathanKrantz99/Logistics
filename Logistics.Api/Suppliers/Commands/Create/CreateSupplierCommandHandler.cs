using Logistics.Api.Common;
using Logistics.Domain.Suppliers;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Create
{
    internal class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result<bool, HandlerError>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var newSupplier = Supplier.Create(request.Name);

            _supplierRepository.Add(newSupplier);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
