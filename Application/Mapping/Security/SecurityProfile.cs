using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SessionNine.Application.Models.Security;
using SessionNine.Domains.Entity;

namespace SessionNine.Application.Mapping
{
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {

            CreateMap<CreateSecurity, Security>();
            CreateMap<Security , ShowSecurityList>();
            CreateMap<CreateSecurityTwo , Security>();
        }
    }
}
