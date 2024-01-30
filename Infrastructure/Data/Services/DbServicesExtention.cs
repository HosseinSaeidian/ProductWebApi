using System.Linq.Dynamic.Core;
using ProductWebApi.Infrastructure.Data.Services.Paging;

namespace ProductWebApi.Infrastructure.Data.Services
{
    public static class DbServicesExtention
    {
        public static IQueryable<T> Query<T>(this IQueryable<T> query, string? fillter)
        {
            if (string.IsNullOrEmpty(fillter))
            {
                return query;
            }

            return query.Where(fillter);
        }


        public static IQueryable<T> Paging<T>(this IQueryable<T> query, PagingParam? paging = default)
        {

            if (paging == null)
            {
                paging = new PagingParam();

            }

            return
            query
            .Skip(paging.PageSize * (paging.PageIndex - 1))
            .Take(paging.PageSize);

        }

    }
}