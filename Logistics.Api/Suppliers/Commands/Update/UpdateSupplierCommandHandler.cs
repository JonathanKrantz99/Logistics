using Logistics.Api.Common;
using Logistics.Domain.Suppliers;
using Logistics.Domain.Interfaces;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Update
{
    internal class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result<bool, HandlerError>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool, HandlerError>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetById(request.SupplierId);

            if (supplier is null)
            {
                return HandlerError.Create($"Supplier with id: {request.SupplierId} was not found.");
            }

            supplier.UpdateInformation(request.Name);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
