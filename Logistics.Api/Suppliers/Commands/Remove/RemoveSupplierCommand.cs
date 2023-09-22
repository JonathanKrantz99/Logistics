using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Remove
{
    internal record RemoveSupplierCommand(Guid SupplierId) : IRequest<Result<bool, HandlerError>>;
}
