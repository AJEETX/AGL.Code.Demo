using Agl.WebApi.Domain.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agl.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressMapClientErrors = true;
            });
            services.AddControllers();
            services.AddCustomServices(Configuration).AddSwagger();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()).UseRouting().UseSwaggerEx().UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
