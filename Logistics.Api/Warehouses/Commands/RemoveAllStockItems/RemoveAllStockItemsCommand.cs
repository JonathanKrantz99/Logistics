using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveAllStockItems
{
    internal record RemoveAllStockItemsCommand(Guid WarehouseId) : IRequest<Result<bool, HandlerError>>;
}
