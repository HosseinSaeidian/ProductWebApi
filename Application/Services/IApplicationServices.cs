using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Services
{
    public interface IApplicationServices
    {
        string HashPassword(string password);
    }
}