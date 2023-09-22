using Logistics.Api.DTOs;
using Logistics.Domain.Warehouses;
using MediatR;

namespace Logistics.Api.Warehouses.Queries.GetAll
{
    internal record GetAllWarehousesQuery(Guid? ProductSearch) : IRequest<List<WarehouseDTO>>;
}
