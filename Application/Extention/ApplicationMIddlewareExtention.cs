using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNine.Application.Extention
{
    public static class ApplicationMIddlewareExtention
    {
        public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app , IWebHostEnvironment environment)
        {
            
            // Configure the HTTP request pipeline.

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
