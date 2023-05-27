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

        public string CustomerPhoneNumber { get; set; }

        public DateTime ReservedFrom { get; set; }

		public DateTime ReservedUntil { get; set; }

        public Guid RentedProductId { get; set; }
        public RentableProduct RentedProduct { get; set; }

        public Guid? ProductReturnalInfoId { get; set; }
        public ProductReturnalInfo? ProductReturnalInfo { get; set; }
    }
}

