using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Application.Validation;

namespace SessionNine.Application.Models
{
    public class CreateProductOne
    {
        [ProductNameValidator("Field Name has problem")]
        public string? Name { get; set; }

        [Range(1 , 5000 , ErrorMessage = "price can be 1 to 5000")]
        public int Price { get; set; }

        public DateTime DataCreated { get; set; } = DateTime.Now;

        [MaxLength(250 , ErrorMessage = "Description can not be more than 250 char")]
        public string Description { get; set; }
    }
}
