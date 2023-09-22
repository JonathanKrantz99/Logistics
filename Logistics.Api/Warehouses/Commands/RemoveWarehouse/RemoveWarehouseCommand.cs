using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveWarehouse
{
    internal record RemoveWarehouseCommand(Guid WarehouseId) : IRequest<Result<bool, HandlerError>>;
}
