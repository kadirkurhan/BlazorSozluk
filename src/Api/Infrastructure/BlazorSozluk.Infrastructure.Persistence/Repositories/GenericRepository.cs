using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BlazorSozlukContext dbContext;

        protected DbSet<T> entity=> dbContext.Set<T>();

        public GenericRepository(BlazorSozlukContext dbContext)
        {
            this.dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Add(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(T entity)
        {
            await this.entity.AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public Task<int> AddAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrUpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task BulkAdd(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task BulkDelete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task BulkDelete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task BulkDeleteById(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task BulkUpdate(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> predicate, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
