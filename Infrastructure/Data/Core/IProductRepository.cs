using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Domains.Entity;

namespace SessionNine.Infrastructure.Data.Core
{
    public interface IProductRepository : IRepository<int , Product>
    {
        
    }
}