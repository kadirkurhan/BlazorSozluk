﻿using BlazorSozluk.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        // Create
        Task<int> AddAsync(T entity);
        int Add(T entity);
        int Add(IEnumerable<T> entities);
        Task<int> AddAsync(IEnumerable<T> entities);

        // Update
        Task<int> UpdateAsync(T entity);
        int Update(T entity);

        // Delete
        Task<int> DeleteAsync(T entity);
        int Delete(T entity);
        Task<int> DeleteAsync(Guid id);
        int Delete(Guid id);
        bool DeleteRange(Expression<Func<T, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate);

        
        Task<int> AddOrUpdateAsync(T entity);
        int AddOrUpdate(T entity);
        
        // Query
        IQueryable<T> AsQueryable();
        Task<List<T>> GetAll(bool noTracking = true);
        Task<List<T>> GetList(Expression<Func<T,bool>> predicate,bool noTracking=true,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null, params Expression<Func<T,object>>[] includes);
        Task<T> GetByIdAsync(Guid id,bool noTracking=true,params Expression<Func<T, object>>[] includes);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);

        // Bulk
        Task BulkDeleteById(IEnumerable<Guid> ids);
        Task BulkDelete(Expression<Func<T, bool>> predicate);
        Task BulkDelete(IEnumerable<T> entities);
        Task BulkUpdate(IEnumerable<T> entities);
        Task BulkAdd(IEnumerable<T> entities);

    }
}
