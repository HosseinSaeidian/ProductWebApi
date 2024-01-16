using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Domains.Core;

namespace SessionNine.Domains.Entity
{
    public class Security : Entity<Guid>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? Accses { get; set; } = false;


        public Security()
        {
            Id = Guid.NewGuid();
        }
    }
}
