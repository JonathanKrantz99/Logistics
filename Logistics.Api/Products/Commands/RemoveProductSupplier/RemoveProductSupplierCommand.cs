using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Products.Commands.RemoveProductSupplier
{
    internal record RemoveProductSupplierCommand(Guid ProductId, Guid SupplierId) : IRequest<Result<bool, HandlerError>>;
}
