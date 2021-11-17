using IMDB.Domain.Repositories.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Infrastructure.Repositories.v1.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly imdbContext _imdbContext;

        public Repository(imdbContext imdbContext)
        {
            _imdbContext = imdbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _imdbContext.Set<T>().AddAsync(entity);
            await _imdbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _imdbContext.Set<T>().Remove(entity);
            await _imdbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _imdbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _imdbContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
