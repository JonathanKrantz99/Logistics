using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Suppliers.Commands.Create
{
    internal record CreateSupplierCommand(string Name) : IRequest<Result<bool, HandlerError>>;
}
