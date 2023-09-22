using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Products.Commands.Remove
{
    internal record RemoveProductCommand(Guid ProductId) : IRequest<Result<bool, HandlerError>>;
}
