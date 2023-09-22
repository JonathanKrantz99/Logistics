using Logistics.Api.Common;
using Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouseAndCustomer;
using Logistics.Api.Distances.Queries.GetDistanceBetweenWarehouses;
using Logistics.Api.Histories.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get distance between warehouses
        /// </summary>
        /// <param name="sourceWarehouseId"></param>
        /// <param name="targetWarehouseId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Warehouse")]
        public async Task<IActionResult> GetDistanceBetweenWarehouses([Required] Guid sourceWarehouseId, [Required] Guid targetWarehouseId)
        {
            var res = await _mediator.Send(new GetDistanceBetweenWarehousesQuery(sourceWarehouseId, targetWarehouseId));

            return res.Match<IActionResult>(
                success => Ok(success),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Get distance between warehouse and other address
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> GetDistanceBetweenWarehouseAndCustomer([Required] Guid warehouseId, [Required] Address address)
        {
            var res = await _mediator.Send(new GetDistanceBetweenWarehouseAndCustomerQuery(warehouseId, address));

            return res.Match<IActionResult>(
                success => Ok(success),
                failed => BadRequest(failed));
        }
    }
}
