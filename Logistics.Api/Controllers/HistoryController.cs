using Logistics.Api.Histories.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get history of moved stock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetHistoryMovedStock()
        {
            var products = await _mediator.Send(new GetAllHistoriesQuery());

            return Ok(products);
        }
    }
}
