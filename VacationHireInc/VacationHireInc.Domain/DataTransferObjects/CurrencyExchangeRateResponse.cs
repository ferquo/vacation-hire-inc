namespace VacationHireInc.Domain.DataTransferObjects
{
    public class CurrencyExchangeRateResponse
    {
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public int Timestamp { get; set; }
        public string Source { get; set; }
        public IDictionary<string, double> Quotes { get; set; }
    }
}

