namespace VacationHireInc.Domain.DataTransferObjects
{
    public class ProductReturnalInfoDto
	{
        public Guid Id { get; set; }

        public decimal PaidAmount { get; set; }

        public string PaidInCurrency { get; set; }

        public Guid OrderId { get; set; }
    }
}

