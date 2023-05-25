using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationHireInc.Domain.Entities
{
	public class Order
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

		public string CustomerName { get; set; }

		public DateTime ReservedFrom { get; set; }

		public DateTime ReservedUntil { get; set; }

        [Column(TypeName = "money")]
        public decimal PaidAmount { get; set; }

        public string PaidInCurrency { get; set; }
    }
}

