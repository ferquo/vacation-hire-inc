using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
    public class VechicleReturnalInfoCreationDto : ProductReturnalInfoCreationDto
    {
        public decimal FuelPercentage { get; set; }
        public string VechicleDamageNotes { get; set; }
	}
}

