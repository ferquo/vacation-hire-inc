using System;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.Domain.DataTransferObjects
{
    public class VechicleReturnalInfoDto : ProductReturnalInfoDto
    {
        public decimal FuelPercentage { get; set; }
        public string VechicleDamageNotes { get; set; }
    }
}

