using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QA_byBuka.Models;

namespace QA_byBuka
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        internal static string connectionString;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {//.\\MSSQL15.MSSQLSERVER\\MSSQL
            connectionString = "Server=WIN-76PF1NPQ3GO;Initial Catalog=QAdb;Integrated Security=True";

            services.AddTransient<IUserRepository, UserRepository>(provider => new UserRepository(connectionString));
            services.AddTransient<IProblemRepository, ProblemRepository>(provider => new ProblemRepository(connectionString));
            services.AddTransient<IAnswerRepository, AnswerRepository>(provider => new AnswerRepository(connectionString));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                 //  pattern: "{controller=Login}/{action=Login}/{id?}");
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
