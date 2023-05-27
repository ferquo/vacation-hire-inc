using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.VechicleReturnalInfos.Interfaces
{
	public interface ICreateVechicleReturnalInfoStrategy
	{
        Task<VechicleReturnalInfoDto> CreateOrder(VechicleReturnalInfoCreationDto vechicleReturnalInfo);
    }
}

