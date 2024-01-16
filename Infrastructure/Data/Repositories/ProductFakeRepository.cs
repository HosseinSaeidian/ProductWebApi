using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure.Data.Core;

namespace SessionNine.Infrastructure.Data.Repositories
{
    public class ProductFakeRepository : SqlRepository<int , Product> , IProductRepository
    {
        public ProductFakeRepository(CatalogContext context) : base(context)
        {
            
        }
    
    }
}