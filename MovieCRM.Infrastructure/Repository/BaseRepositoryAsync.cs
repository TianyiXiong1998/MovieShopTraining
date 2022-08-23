using Microsoft.EntityFrameworkCore;
using MovieCRM.Core.Contracts.Repository;
using MovieCRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRM.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        MovieShopDbContext db;
        public BaseRepositoryAsync(MovieShopDbContext _content)
        {
            db = _content;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
            else
            {
                db.Set<T>().Remove(entity);
            }
            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await db.Set<T>().FindAsync(id);
            return entity;
        }

        public  Task<int> InsertAsync(T entity)
        {
            db.Set<T>().Add(entity);
            return  db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}
