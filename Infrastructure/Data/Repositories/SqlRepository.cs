using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SessionNine.Domains.Core;
using SessionNine.Infrastructure.Data.Core;

namespace SessionNine.Infrastructure.Data.Repositories
{
    public class SqlRepository<key, T> : IRepository<key, T>
        where T : Entity<key>
        where key : struct
    {

        private readonly CatalogContext _context;
        private readonly DbSet<T> _set;


        public SqlRepository(CatalogContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync<Tvalue>(System.Linq.Expressions.Expression<Func<T, Tvalue>> expression, Tvalue value)
        {
            return await _set.AnyAsync(a => expression.Compile()(a).Equals(value));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistWithIdAsync(key id)
        {
            var result = await _set.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<IEnumerable<T>> GetValuesAll()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetValueWithId(key id) => await _set.FindAsync(id);

        public async Task<IEnumerable<T>> GetWithFillter(Expression<Func<T, bool>> predicate)
        {
            var result = _set.Where(predicate);
            return await result.ToListAsync(); 
        }

        public async Task UpdateAsync(T entity)
        {
            // here use proxy for edit row in database

            var proxy = _context.Entry(entity);
            proxy.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
