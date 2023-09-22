using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Products.Commands.AddSupplier
{
    internal record AddProductSupplierCommand(Guid ProductId, Guid SupplierId) : IRequest<Result<bool, HandlerError>>;
}
