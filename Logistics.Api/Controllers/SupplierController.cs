using Logistics.Api.Suppliers.Commands.Create;
using Logistics.Api.Suppliers.Commands.Remove;
using Logistics.Api.Suppliers.Commands.Update;
using Logistics.Api.Suppliers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all suppliers with products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _mediator.Send(new GetAllSuppliersQuery());

            return Ok(suppliers);
        }

        /// <summary>
        /// Create new supplier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierRequest request)
        {
            var res = await _mediator.Send(new CreateSupplierCommand(request.Name));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Update existing supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{supplierId}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute]Guid supplierId, UpdateSupplierRequest request)
        {
            var res = await _mediator.Send(new UpdateSupplierCommand(supplierId, request.Name));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{supplierId}")]
        public async Task<IActionResult> RemoveSupplier([FromRoute] Guid supplierId)
        {
            var res = await _mediator.Send(new RemoveSupplierCommand(supplierId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }
    }
}
