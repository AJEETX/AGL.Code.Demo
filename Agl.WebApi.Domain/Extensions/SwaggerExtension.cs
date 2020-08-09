using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Agl.WebApi.Domain.Extensions
{
    internal static partial class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AGL Demo API",
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Agl.WebApi.xml");

                c.IncludeXmlComments(xmlPath);
            });
            
            return services;
        }
        public static IApplicationBuilder UseSwaggerEx(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agl Demo Api");
                c.RoutePrefix = "";
            });

            return app;
        }
    }
}
