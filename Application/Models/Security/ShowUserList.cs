using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Models.Security
{
    public class ShowSecurityList
    {

        // این پراپ برای شناسه داخل دیتابیس است
        public Guid Id { get; set; }

        // این پراپ برای یوزرنیم کاربر هست که همون کدملیه
        public string? UserName { get; set; }
    }
}