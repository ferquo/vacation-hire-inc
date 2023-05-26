using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories.Interfaces
{
	public interface IOrdersRepository : IGenericRepository<Order>
	{
        Task<IEnumerable<Order>> GetOrdersFiltered(int skip, int take);
        Task<int> GetTotalMatchingFilter();
        Task<bool> Exists(Guid id);
    }
}

