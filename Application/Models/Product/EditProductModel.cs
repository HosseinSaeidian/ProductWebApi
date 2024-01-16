
using SessionNine.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace SessionNine.Application.Models.Product
{
    public class EditProductModel
    {
        [ProductNameValidator("Field Name has problem")]
        public string? Name { get; set; }

        [Range(1 , 2500 , ErrorMessage = "price can be 1 to 2500")]
        public int Price { get; set; }
        
        public DateTime DataModified { get; set; } = DateTime.Now;

        [MaxLength(250 , ErrorMessage = "Description can not be more than 250 char")]
        public string Description { get; set; }
    }
}