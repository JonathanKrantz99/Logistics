using Logistics.Api.DTOs;
using MediatR;

namespace Logistics.Api.Suppliers.Queries.GetAll
{
    internal record GetAllSuppliersQuery() : IRequest<List<SupplierDTO>>;
}
