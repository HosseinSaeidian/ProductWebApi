using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Domains.Core;

namespace SessionNine.Domains.Entity
{
    public class Product : Entity<int>
    {
    // comment on product Class
        public string? Name { get; set; }
        public int Price { get; set; }
        
    }
}
