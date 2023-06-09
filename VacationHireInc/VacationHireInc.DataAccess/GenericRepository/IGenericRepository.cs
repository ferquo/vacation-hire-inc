﻿using System;
namespace VacationHireInc.DataAccess.GenericRepository
{
	public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(Guid id);
    }
}

