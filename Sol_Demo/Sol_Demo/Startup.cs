using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Sol_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<LocalStorageConfiguration>((leServiceProvider) =>
            {
                return new LocalStorageConfiguration()
                {
                    EnableEncryption = true,
                    EncryptionSalt = "f73841e69d767344416590b95224fe2f73841e69d767344416590b95224fe2f73841e69d767344416590b95224fe2f73841e69d767344416590b95224fe2"
                };
            });
            services.AddTransient<LocalStorage>((leServiceProvider) =>
            {
                var localConfig = leServiceProvider.GetService(typeof(LocalStorageConfiguration)) as ILocalStorageConfiguration;

                return new LocalStorage(localConfig,"setyourpassword");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LocalStorageDemo}/{action=Index}/{id?}");
            });
        }
    }
}