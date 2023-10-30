using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ptj_server.DatabaseContext;
using ptj_server.Interfaces;

namespace ptj_server.Repositories
{ 
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _db;

        public BaseRepository(DataContext db)
        {
            _db = db;
        }

        public IQueryable<T> Entities => _db.Set<T>();

        public int Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return _db.SaveChanges();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            _db.Remove<T>(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public Task<T> GetByAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _db.Set<T>();

            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _db.Set<T>()
                .FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetListByAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _db.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}

