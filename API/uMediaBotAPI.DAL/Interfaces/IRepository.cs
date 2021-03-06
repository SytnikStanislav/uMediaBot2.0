﻿using uMediaBotAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace uMediaBotAPI.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity:Entity
    {
        TEntity Create(TEntity entity);
        bool Delete(int id);
        TEntity Update(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefaultAsync(
                      Expression<Func<TEntity, bool>> predicate = null,
                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
                                         
        Task<List<TEntity>> GetAllEntities(
                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}
