using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.AddStockItem
{
    internal record AddStockItemCommand(Guid WarehouseId, Guid ProductId, Guid SupplierId, int quantity) : IRequest<Result<bool, HandlerError>>;
}
