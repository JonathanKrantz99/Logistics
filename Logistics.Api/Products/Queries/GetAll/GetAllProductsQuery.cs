using Logistics.Api.DTOs;
using Logistics.Domain.Products;
using MediatR;

namespace Logistics.Api.Products.Queries.GetAll
{
    internal record GetAllProductsQuery() : IRequest<List<ProductDTO>>;
}
