using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationHireInc.Domain.Entities
{
    public class ProductReturnalInfo
	{
		public Guid Id { get; set; }

        [Column(TypeName = "money")]
        public decimal PaidAmount { get; set; }

        public string PaidInCurrency { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}

