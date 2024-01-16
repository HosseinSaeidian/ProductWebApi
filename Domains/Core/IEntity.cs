using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Domains.Core
{
    public interface IEntity<key>
    {
        key Id { get; set; }
        DateTime DataCreated { get; set; }
        string? Description { get; set; }
    }
}

