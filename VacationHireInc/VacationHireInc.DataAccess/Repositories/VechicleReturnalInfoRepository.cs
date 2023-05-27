using System;
using Microsoft.EntityFrameworkCore;
using VacationHireInc.DataAccess.GenericRepository;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.DataAccess.Repositories
{
	public class VechicleReturnalInfoRepository : GenericRepository<VechicleReturnalInfo>, IVechicleReturnalInfoRepository
    {
		public VechicleReturnalInfoRepository(VacationHireIncContext db) : base(db)
        {
        }

        public async Task<bool> ReturnalExistsForOrder(Guid orderId)
        {
            return await db.VechicleReturnalInfos.AsNoTracking().AnyAsync(x => x.OrderId == orderId);
        }
    }
}

