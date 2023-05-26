using System;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VacationHireInc.DataAccess.Repositories
{
	public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(VacationHireIncContext db) : base(db)
        {
        }

        public async Task<bool> Exists(Guid id)
        {
            return await db.Orders.AsNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersFiltered(int skip, int take)
        {
            return await db.Orders
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetTotalMatchingFilter()
        {
            // since there are no orderings/filterings implemented, just get the total count
            return await db.Orders
                .AsNoTracking()
                .CountAsync();
        }
    }
}

