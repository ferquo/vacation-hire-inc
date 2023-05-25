using System;

namespace VacationHireInc.Domain.DataTransferObjects
{
	public class OrderDto
	{
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedUntil { get; set; }

        public decimal PaidAmount { get; set; }

        public string PaidInCurrency { get; set; }
    }
}

