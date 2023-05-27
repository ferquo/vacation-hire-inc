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
        private readonly IGeCurrencyExchangeRateToUSDStrategy geCurrencyExchangeRateToUSDStrategy;

        public CurrenciesController(
            IGetAllCurrenciesStrategy getAllCurrenciesStrategy,
            IGeCurrencyExchangeRateToUSDStrategy geCurrencyExchangeRateToUSDStrategy)
		{
            this.getAllCurrenciesStrategy = getAllCurrenciesStrategy;
            this.geCurrencyExchangeRateToUSDStrategy = geCurrencyExchangeRateToUSDStrategy;
        }

        [HttpGet("", Name = "GetCurrencies")]
        public async Task<IActionResult> Get()
        {
            var currencies = await getAllCurrenciesStrategy.GetCurrencies();
            return Ok(currencies);
        }

        [HttpGet("{currency}", Name = "GetExchangeRateToUSD")]
        public async Task<IActionResult> Get(string currency)
        {
            var exchangeRate = await geCurrencyExchangeRateToUSDStrategy.GetExchangeRate(currency);
            return Ok(exchangeRate);
        }
    }
}

