using Agl.WebApi.Domain.Proxy;
using Agl.WebApi.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Agl.WebApi.Domain.Extensions
{
    internal static partial class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPetsOwnerService, PetsOwnerService>();
            
            services.AddHttpClient<IHttpClientProxy, HttpClientProxy>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("BaseUrl").Value);
            });

            return services;
        }
    }
}
