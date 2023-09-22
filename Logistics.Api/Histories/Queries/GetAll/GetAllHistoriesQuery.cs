using Logistics.Api.DTOs;
using MediatR;

namespace Logistics.Api.Histories.Queries.GetAll
{
    internal record GetAllHistoriesQuery() : IRequest<List<HistoryDTO>>;
}
