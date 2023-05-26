using System;
using Microsoft.AspNetCore.Mvc;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.RentableProducts.Interfaces;

namespace VacationHireInc.API.Controllers
{
    [Route("api/rentable-products")]
    [ApiController]
    public class RentableProductController : ControllerBase
    {
        private readonly IGetRentableProductsStrategy getRentableProductsStrategy;

        public RentableProductController(
            IGetRentableProductsStrategy getRentableProductsStrategy)
		{
            this.getRentableProductsStrategy = getRentableProductsStrategy;
        }

        [HttpGet("", Name = "GetRentableProducts")]
        public async Task<IActionResult> Get()
        {
            var orders = await getRentableProductsStrategy.GetAllRentableProducts();
            return Ok(orders);
        }
    }
}

