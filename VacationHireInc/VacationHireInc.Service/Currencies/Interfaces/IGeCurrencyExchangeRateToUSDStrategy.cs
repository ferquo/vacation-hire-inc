using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Currencies.Interfaces
{
	public interface IGeCurrencyExchangeRateToUSDStrategy
	{
        Task<ExchangeRateToUSDDto> GetExchangeRate(string currency);
    }
}

