using System.Linq.Dynamic.Core;
using ProductWebApi.Infrastructure.Data.Services.Paging;
using Microsoft.EntityFrameworkCore;
using SessionNine.Domains.Core;
using System.Reflection.Metadata.Ecma335;

namespace ProductWebApi.Infrastructure.Data.Services
{
    public static class DbServicesExtention
    {
        public static IQueryable<T> QueryService<T>(this IQueryable<T> query, string? fillter)
        {
            return string.IsNullOrEmpty(fillter)?  query : query.Where(fillter);
        }


        public static IQueryable<T> PagingService<T>(this IQueryable<T> query, PagingParam? paging = default)
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

        public static IQueryable<T> OrderingSerivec<T>(this IQueryable<T> query, string? sort = default)
        {
            return string.IsNullOrEmpty(sort) ? query : query.OrderBy(sort);
        }

        
        public static IQueryable<T> TrackingService<T>(this IQueryable<T> query, bool active = default)
        where T : class
        {
            return active ? query : query.AsNoTracking();
        }

    }
}