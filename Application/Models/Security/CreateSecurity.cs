using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SessionNine.Application.Validation;

namespace SessionNine.Application.Models.Security
{

    public class CreateSecurity
    {

        // این ولیدیشن برای چک کردن یوزرنیم است
        [UserNameRuleOne("UserName should be not null and should 10 char")]
        public string? UserName { get; set; }


        //این قسمت برای چک کردن پسورد است
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }


        public DateTime DataCreated { get; set; } = DateTime.Now;

        //این قسمت هم به همین شکل برای تست نوشته شده است
        [MaxLength(250, ErrorMessage = "Description only can write 250 char")]
        public string? Description { get; set; }
    }
}
