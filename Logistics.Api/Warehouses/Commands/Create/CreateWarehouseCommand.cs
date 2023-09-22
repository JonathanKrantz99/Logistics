using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.Create
{
    public record CreateWarehouseCommand(string Name, Address WarehouseAddress) : IRequest<Result<bool, HandlerError>>;
}
