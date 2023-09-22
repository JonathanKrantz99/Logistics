using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Update
{
    internal record UpdateSupplierCommand(Guid SupplierId, string Name) : IRequest<Result<bool, HandlerError>>;
}
