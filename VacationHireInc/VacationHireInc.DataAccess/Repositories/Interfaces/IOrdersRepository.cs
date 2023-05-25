using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories.Interfaces
{
	public interface IOrdersRepository : IGenericRepository<Order>
	{
	}
}

