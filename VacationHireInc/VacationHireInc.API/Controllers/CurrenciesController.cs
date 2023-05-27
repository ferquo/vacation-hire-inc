using System;
using Microsoft.AspNetCore.Mvc;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Currencies.Interfaces;
using VacationHireInc.Service.Orders;

namespace VacationHireInc.API.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrenciesController : ControllerBase
	{
        private readonly IGetAllCurrenciesStrategy getAllCurrenciesStrategy;

        public CurrenciesController(
            IGetAllCurrenciesStrategy getAllCurrenciesStrategy)
		{
            this.getAllCurrenciesStrategy = getAllCurrenciesStrategy;
        }

        [HttpGet("", Name = "GetCurrencies")]
        public async Task<IActionResult> Get()
        {
            var currencies = await getAllCurrenciesStrategy.GetCurrencies();
            return Ok(currencies);
        }
    }
}

