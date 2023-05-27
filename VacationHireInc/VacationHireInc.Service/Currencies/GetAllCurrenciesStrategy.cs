using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Currencies.Interfaces;

namespace VacationHireInc.Service.Currencies
{
    public class GetAllCurrenciesStrategy : IGetAllCurrenciesStrategy
    {
        private readonly IConfiguration configuration;

        public GetAllCurrenciesStrategy(
            IConfiguration configuration)
		{
            this.configuration = configuration;
        }

        public async Task<IEnumerable<CurrencyDto>> GetCurrencies()
        {
            string apiKey = configuration["CurrencyLayerOptions:ApiKey"] ?? string.Empty;
            string baseUrl = configuration["CurrencyLayerOptions:ApiBaseUrl"] ?? string.Empty;

            var options = new RestClientOptions(baseUrl);
            var client = new RestClient(options);
            var request = new RestRequest("list");
            request.AddQueryParameter("access_key", apiKey);
            var response = await client.GetAsync<CurrencyListResponse>(request);
            return response?
                .Currencies
                .Select(x => new CurrencyDto { Key = x.Key, Value = x.Value })
                .ToList();
        }
	}
}

