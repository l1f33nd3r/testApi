using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestHttp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>(opt => opt.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password"));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            UpdateDatabase(app);
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            try
            {
                using var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                using var context = serviceScope.ServiceProvider.GetService<AppContext>();
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
