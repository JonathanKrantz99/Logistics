using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.MoveStockItems
{
    internal record MoveStockItemsCommand(Guid WarehouseId, Guid NewWarehouseId, Guid ProductId, Guid SupplierId, int Quantity) : IRequest<Result<bool, HandlerError>>;
}
