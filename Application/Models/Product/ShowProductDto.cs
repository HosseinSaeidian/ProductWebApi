using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Models
{
    public class ShowProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DataCreated { get; set; }
        public string Description { get; set; }
        
    }
}