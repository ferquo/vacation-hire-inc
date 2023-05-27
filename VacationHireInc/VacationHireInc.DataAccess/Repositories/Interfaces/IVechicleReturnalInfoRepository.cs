using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories.Interfaces
{
	public interface IVechicleReturnalInfoRepository : IGenericRepository<VechicleReturnalInfo>
    {
		Task<bool> ReturnalExistsForOrder(Guid orderId);
	}
}

