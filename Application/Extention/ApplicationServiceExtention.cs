using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure;
using SessionNine.Infrastructure.Data.Core;
using SessionNine.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SessionNine.Application.Services;
using System.Reflection;

namespace SessionNine.Application.Extention
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection InjectServicesExtention(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IProductRepository, ProductFakeRepository>();
            services.AddScoped<ISecurityRepository , SecurityRepository>();
            services.AddSingleton<IApplicationServices , ApplicationServicesRepository>(); 

            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
            services.AddDbContext<CatalogContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("testconnection"))
            );


            return services;
        }
    }
}
