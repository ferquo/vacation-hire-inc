using System;
using Microsoft.AspNetCore.Mvc;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.Orders.Interfaces;

namespace VacationHireInc.API.Controllers
{
    [Route("api/orders")]
	[ApiController]
    public class OrdersController : ControllerBase
	{
        private readonly ILogger<OrdersController> logger;
        private readonly ICreateOrderStrategy createOrderStrategy;
        private readonly IGetOrderStrategy getOrderStrategy;
        private readonly IGetOrdersStrategy getOrdersStrategy;

        public OrdersController(
            ILogger<OrdersController> logger,
            ICreateOrderStrategy createOrderStrategy,
            IGetOrderStrategy getOrderStrategy,
            IGetOrdersStrategy getOrdersStrategy)
		{
            this.logger = logger;
            this.createOrderStrategy = createOrderStrategy;
            this.getOrderStrategy = getOrderStrategy;
            this.getOrdersStrategy = getOrdersStrategy;
        }

        [HttpGet("", Name = "GetOrders")]
        public async Task<IActionResult> Get([FromQuery] FilterRequest filter)
        {
            var orders = await getOrdersStrategy.GetOrders(filter);
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> Get(Guid id)
        {
            var orderToReturn = await getOrderStrategy.GetOrder(id);
            return Ok(orderToReturn);
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> Post([FromBody] OrderForCreationDto order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var orderToReturn = await createOrderStrategy.CreateOrder(order);
            return Created("GetOrder", orderToReturn);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
            // await deleteOrderStrategy.Delete(id);
            // return NoContent();
        }
    }
}

