using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Currencies.Interfaces
{
	public interface IGetAllCurrenciesStrategy
	{
        Task<IEnumerable<CurrencyDto>> GetCurrencies();
    }
}

