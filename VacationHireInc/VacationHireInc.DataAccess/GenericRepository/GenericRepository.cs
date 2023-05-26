using System;
using Microsoft.EntityFrameworkCore;

namespace VacationHireInc.DataAccess.GenericRepository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        protected VacationHireIncContext db;

        public GenericRepository(VacationHireIncContext db)
        {
            this.db = db;
        }

        public async Task Create(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await db.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await db.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}

