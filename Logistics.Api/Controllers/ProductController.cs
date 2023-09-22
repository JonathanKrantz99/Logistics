using Logistics.Api.Products.Commands.AddSupplier;
using Logistics.Api.Products.Commands.Create;
using Logistics.Api.Products.Commands.Remove;
using Logistics.Api.Products.Commands.RemoveProductSupplier;
using Logistics.Api.Products.Commands.Update;
using Logistics.Api.Products.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products with product suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var res = await _mediator.Send(new CreateProductCommand(request.Name));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]Guid productId, UpdateProductRequest request)
        {
            var res = await _mediator.Send(new UpdateProductCommand(productId, request.Name));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Add supplier to product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{productId}/Supplier/{supplierId}/Add")]
        public async Task<IActionResult> AddSupplier([FromRoute] Guid productId, [FromRoute] Guid supplierId)
        {
            var res = await _mediator.Send(new AddProductSupplierCommand(productId, supplierId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove supplier from product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{productId}/Supplier/{supplierId}/Remove")]
        public async Task<IActionResult> RemoveSupplier([FromRoute] Guid productId, [FromRoute] Guid supplierId)
        {
            var res = await _mediator.Send(new RemoveProductSupplierCommand(productId, supplierId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> RemoveProduct([FromRoute] Guid productId)
        {
            var res = await _mediator.Send(new RemoveProductCommand(productId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }
    }
}
