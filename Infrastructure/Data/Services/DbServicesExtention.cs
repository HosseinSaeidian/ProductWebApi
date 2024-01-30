using System.Linq.Dynamic.Core;

namespace ProductWebApi.Infrastructure.Data.Services
{
    public static class DbServicesExtention
    {
        public static IQueryable<T> Query<T>(this IQueryable<T> query , string? fillter)
        {
            if (string.IsNullOrEmpty(fillter))
            {
                return query;
            }

            return query.Where(fillter);
        }
        
    }
}