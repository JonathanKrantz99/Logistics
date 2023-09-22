using Logistics.Api.Common;
using MediatR;

namespace Logistics.Api.Warehouses.Commands.RemoveAllStockItemsBySupplier
{
    internal record RemoveAllStockItemsBySupplierCommand(Guid WarehouseId, Guid SupplierId) : IRequest<Result<bool, HandlerError>>;
}
