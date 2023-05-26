using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
    public class RentableProductDto : IRentableProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProductType { get; set; }
    }
}

