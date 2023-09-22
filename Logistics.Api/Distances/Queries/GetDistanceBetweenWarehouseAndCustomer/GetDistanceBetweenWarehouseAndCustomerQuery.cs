using Logistics.Api.Common;
using Logistics.Api.DTOs;
using MediatR;

namespace Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouseAndCustomer
{
    internal record GetDistanceBetweenWarehouseAndCustomerQuery(Guid WarehouseId, Address Address) : IRequest<Result<DistanceDTO, HandlerError>>;
}
