using FortCode.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FortCode
{
    public class Startup
    {

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc();

            services
                .AddControllers();
            services.AddAuthentication(options => options.DefaultAuthenticateScheme = "User.Email & User.Password");

            services.AddDbContext<UserDbContext>(options => options.UseSqlServer("ConnectionStrings: DbContext"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app
                .UseRouting()
                .UseEndpoints(endPoints => { endPoints.MapControllers(); });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
        }
    }
}
