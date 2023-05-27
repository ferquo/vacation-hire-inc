using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories.Interfaces
{
	public interface IRentableProductRepository : IGenericRepository<RentableProduct>
    {
        Task<bool> Exists(Guid id);
    }
}

