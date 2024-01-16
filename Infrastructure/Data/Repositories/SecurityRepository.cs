using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure.Data.Core;

namespace SessionNine.Infrastructure.Data.Repositories
{
    public class SecurityRepository : SqlRepository<Guid, Security>, ISecurityRepository
    {
        public SecurityRepository(CatalogContext context) : base(context)
        {
        }
        
    }
}