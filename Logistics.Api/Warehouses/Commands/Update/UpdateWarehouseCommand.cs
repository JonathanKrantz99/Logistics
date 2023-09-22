using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.Update
{
    internal record UpdateWarehouseCommand(Guid WarehouseId, string Name, Address WarehouseAddress) : IRequest<Result<bool, HandlerError>>;
}
