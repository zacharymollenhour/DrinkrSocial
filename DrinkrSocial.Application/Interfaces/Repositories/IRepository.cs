using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        // Add a entity
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity GetById(TKey id);

        Task<TEntity> GetByIdAsync(TKey id);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, bool noTracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, bool noTracking = true);

        TEntity Get(Expression<Func<TEntity, bool>> expression, bool noTracking = false);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, bool noTracking = false);

        IQueryable<TEntity> Queryable();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);

        int GetCount(Expression<Func<TEntity, bool>> expression = null);

    }
}
