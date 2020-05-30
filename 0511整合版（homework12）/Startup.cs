using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api
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
            services.AddDbContextPool<OrderContext>(options => options
                .UseMySql(Configuration.GetConnectionString("orderDatabase"),
                mySqlOptions => mySqlOptions.ServerVersion(new Version(8, 0, 18), ServerType.MySql)
            ));

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { 
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection(); 
            app.UseRouting();  
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers(); 
            });
        }
    }
}
