using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SessionNine.Application.Services
{
    public  class ApplicationServicesRepository  : IApplicationServices
    {

        public  string HashPassword(string password)
        {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
        }
    }
}
