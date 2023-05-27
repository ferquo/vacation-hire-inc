using Microsoft.Extensions.Configuration;
using RestSharp;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Currencies.Interfaces;

namespace VacationHireInc.Service.Currencies
{
    /// <summary>
    /// I will only implement exchange rates to USD, as this is the only one allowed in the free tier
    /// </summary>
    public class GeCurrencyExchangeRateToUSDStrategy : IGeCurrencyExchangeRateToUSDStrategy
    {
        private readonly IConfiguration configuration;

        public GeCurrencyExchangeRateToUSDStrategy(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<ExchangeRateToUSDDto> GetExchangeRate(string currency)
        {
            string apiKey = configuration["CurrencyLayerOptions:ApiKey"] ?? string.Empty;
            string baseUrl = configuration["CurrencyLayerOptions:ApiBaseUrl"] ?? string.Empty;

            var options = new RestClientOptions(baseUrl);
            var client = new RestClient(options);
            var request = new RestRequest("live");
            request.AddQueryParameter("access_key", apiKey);
            request.AddQueryParameter("currencies", currency);
            var response = await client.GetAsync<CurrencyExchangeRateResponse>(request);
            return new ExchangeRateToUSDDto
            {
                Currency = response?.Quotes?.First().Key,
                Rate = response?.Quotes.First().Value ?? 0,
            };
        }
    }
}

