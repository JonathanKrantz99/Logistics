using Logistics.Api.Common;
using Logistics.Api.DTOs;
using MediatR;

namespace Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouses
{
    internal record GetDistanceBetweenWarehousesQuery(Guid SourceWarehouseId, Guid TargetWarehouseId) : IRequest<Result<DistanceDTO, HandlerError>>;
}
