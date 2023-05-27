using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.VechicleReturnalInfos.Interfaces
{
	public interface IGetVechicleReturnalInfoStrategy
	{
        Task<VechicleReturnalInfoDto> GetVechicleReturnalInfo(Guid id);
    }
}

