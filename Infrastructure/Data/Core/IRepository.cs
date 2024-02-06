using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductWebApi.Infrastructure.Data.Services.Paging;
using SessionNine.Domains.Core;

namespace SessionNine.Infrastructure.Data.Core
{
    public interface IRepository<key, T>
    where T : Entity<key>
    where key : struct

    {
        void Add(T entity);

        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetValuesAll();

        Task<IEnumerable<T>> FillterAsync(string predicate, string? Sort = default, PagingParam? paging = null , bool track = false);

        Task<T?> GetValueWithId(key id);

        Task<bool> ExistAsync<Tvalue>(Expression<Func<T, Tvalue>> expression, Tvalue value);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistWithIdAsync(key id);

    }
}