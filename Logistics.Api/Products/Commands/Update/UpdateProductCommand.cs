using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Products.Commands.Update
{
    internal record UpdateProductCommand(Guid ProductId, string Name) : IRequest<Result<bool, HandlerError>>;
}
