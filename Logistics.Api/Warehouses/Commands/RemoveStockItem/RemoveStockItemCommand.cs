using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveStockItem
{
    internal record RemoveStockItemCommand(Guid WarehouseId, Guid ProductId, Guid SupplierId, int Quantity) : IRequest<Result<bool, HandlerError>>;
}
