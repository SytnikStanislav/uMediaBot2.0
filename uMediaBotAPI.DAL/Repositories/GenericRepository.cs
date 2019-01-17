using AutoMapper;
using uMediaBotAPI.DAL.Data;
using uMediaBotAPI.DAL.Entities;
using uMediaBotAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace uMediaBotAPI.DAL.Repositories
{
    public class GenericRepository<TEntity>:IRepository<TEntity> where TEntity:Entity
    {
        protected readonly MediaBotDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IMapper mapper;

        public GenericRepository(MediaBotDbContext context, IMapper automapper)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            mapper = automapper;
        }

        public TEntity Create(TEntity entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public bool Delete(int id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            if (entityToDelete == null)
            {
                throw new Exception($"Entity with id: {id} not found when trying to update entity. Entity was no Deleted.");
            }

            return Delete(entityToDelete);
        }

        public bool Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            try
            {
                DbSet.Remove(entityToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().CountAsync(predicate);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(
                                   Expression<Func<TEntity, bool>> predicate = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            
            return entity;
        }

        public Task<List<TEntity>> GetAllEntities(
                                   Func<IQueryable<TEntity>, 
                                   IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (include != null)
            {
                query = include(query);
            }

            return query.ToListAsync();
        }
    }
}
