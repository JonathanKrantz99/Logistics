using Logistics.Api.Warehouses.Commands.AddStockItem;
using Logistics.Api.Warehouses.Commands.Create;
using Logistics.Api.Warehouses.Commands.MoveStockItems;
using Logistics.Api.Warehouses.Commands.RemoveAllStockItems;
using Logistics.Api.Warehouses.Commands.RemoveAllStockItemsByProduct;
using Logistics.Api.Warehouses.Commands.RemoveAllStockItemsBySupplier;
using Logistics.Api.Warehouses.Commands.RemoveStockItem;
using Logistics.Api.Warehouses.Commands.RemoveWarehouse;
using Logistics.Api.Warehouses.Commands.Update;
using Logistics.Api.Warehouses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all warehouses with products
        /// </summary>
        /// <param name="productSearch"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? productSearch)
        {
            var response = await _mediator.Send(new GetAllWarehousesQuery(productSearch));
            
            return Ok(response);
        }

        /// <summary>
        /// Create new warehouse
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWarehouse(CreateWarehouseRequest request)
        {
            var res = await _mediator.Send(new CreateWarehouseCommand(request.Name, request.Address));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Update existing warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{warehouseId}")]
        public async Task<IActionResult> UpdateWarehouse([FromRoute] Guid warehouseId, UpdateWarehouseRequest request)
        {
            var res = await _mediator.Send(new UpdateWarehouseCommand(warehouseId, request.Name, request.Address));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Add stock to warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Add")]
        public async Task<IActionResult> AddStock([FromRoute]Guid warehouseId, AddStockItemRequest request)
        {
            var res = await _mediator.Send(new AddStockItemCommand(warehouseId, request.ProductId, request.SupplierId, request.Quantity));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Move stock to another warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Move")]
        public async Task<IActionResult> MoveStock([FromRoute] Guid warehouseId, MoveStockItemsRequest request)
        {
            var res = await _mediator.Send(new MoveStockItemsCommand(warehouseId, request.TargetWarehouseId, request.ProductId, request.SupplierId, request.Quantity));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove quantity of stock from warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Remove")]
        public async Task<IActionResult> RemoveStockItemsByQuantity([FromRoute] Guid warehouseId, RemoveStockItemRequest request)
        {
            var res = await _mediator.Send(new RemoveStockItemCommand(warehouseId, request.ProductId, request.SupplierId, request.Quantity));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }


        /// <summary>
        /// Remove all stock from warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Remove/All")]
        public async Task<IActionResult> RemoveAllStockItems([FromRoute] Guid warehouseId)
        {
            var res = await _mediator.Send(new RemoveAllStockItemsCommand(warehouseId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove all stock from warehouse by product id
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Remove/Product/{productId}")]
        public async Task<IActionResult> RemoveAllStockItemsByProduct([FromRoute] Guid warehouseId, [FromRoute] Guid productId)
        {
            var res = await _mediator.Send(new RemoveAllStockItemsByProductCommand(warehouseId, productId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove all stock from warehouse delivered by specific supplier
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{warehouseId}/Stock/Remove/Supplier/{supplierId}")]
        public async Task<IActionResult> RemoveAllStockItemsBySupplier([FromRoute] Guid warehouseId, [FromRoute] Guid supplierId)
        {
            var res = await _mediator.Send(new RemoveAllStockItemsBySupplierCommand(warehouseId, supplierId));

            return res.Match<IActionResult>(
                success => Ok(),
                failed => BadRequest(failed));
        }

        /// <summary>
        /// Remove warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{warehouseId}")]
        public async Task<IActionResult> RemoveWarehouse([FromRoute] Guid warehouseId)
        {
            var res = await _mediator.Send(new RemoveWarehouseCommand(warehouseId));

            return res.Match<IActionResult>(
            success => Ok(),
                failed => BadRequest(failed));
        }
    }
}
