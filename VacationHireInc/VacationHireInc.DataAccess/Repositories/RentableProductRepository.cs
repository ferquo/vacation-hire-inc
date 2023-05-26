using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories
{
	public class RentableProductRepository : GenericRepository<RentableProduct>, IRentableProductRepository
    {
		public RentableProductRepository(VacationHireIncContext db) : base(db)
        {
		}
	}
}

