using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
    public class OrderForCreationDto
    {
        public string CustomerName { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedUntil { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public Guid RentedProductId { get; set; }

    }
}

