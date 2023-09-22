using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Products.Commands.Create
{
    internal record CreateProductCommand(string Name) : IRequest<Result<bool, HandlerError>>;
}
