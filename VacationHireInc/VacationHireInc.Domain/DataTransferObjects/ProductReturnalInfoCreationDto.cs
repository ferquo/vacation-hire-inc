namespace VacationHireInc.Domain.DataTransferObjects
{
    public class ProductReturnalInfoCreationDto
    {
        public decimal PaidAmount { get; set; }

        public string PaidInCurrency { get; set; }

        public Guid OrderId { get; set; }
    }
}

