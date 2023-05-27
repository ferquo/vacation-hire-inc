using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
	public class CurrencyListResponse
	{
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public IDictionary<string, string> Currencies { get; set; }
    }
}

