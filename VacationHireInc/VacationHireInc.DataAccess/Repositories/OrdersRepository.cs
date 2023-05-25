using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories
{
	public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(VacationHireIncContext db) : base(db)
        {
        }
    }
}

