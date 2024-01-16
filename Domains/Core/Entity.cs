using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Domains.Core
{
    public class Entity<key> : IEntity<key>
        where key : struct
    {
        public key Id { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataModified { get; set; }
        public string? Description { get; set; } = null;
    }
}
