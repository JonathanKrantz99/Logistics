using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveAllStockItemsByProduct
{
    internal record RemoveAllStockItemsByProductCommand(Guid WarehouseId, Guid ProductId) : IRequest<Result<bool, HandlerError>>;
}
