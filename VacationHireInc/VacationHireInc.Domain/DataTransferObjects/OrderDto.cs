using System;

namespace VacationHireInc.Domain.DataTransferObjects
{
	public class OrderDto
	{
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedUntil { get; set; }

        public string CustomerPhoneNumber { get; set; }

        /// <summary>
        /// This field represents the rented vehicle
        /// Obeys the open/closed princible
        /// When the Vacation Hire Inc wants to extend its product lineup,
        /// the order model doesn't need to be modified
        /// </summary>
        public IRentableProductDto RentedProduct { get; set; }

        public ProductReturnalInfoDto? ProductReturnalInfo { get; set; }
    }
}

