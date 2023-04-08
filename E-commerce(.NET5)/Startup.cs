using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.AppCode.Middlewares;
using E_commerce_.NET5_.AppCode.Providers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_.NET5_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            string myKey = "Riode";
            string plainText = "test";
            // string hashedText = plaintext.ToMd5();
            string chiperText = plainText.Encrypt(myKey);//kFVbSlCtCkE=

            string myPlainText = chiperText.Decrypt(myKey);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(cfg =>
                {
                    cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                });


            services.AddControllersWithViews();
            services.AddRouting(cfg => cfg.LowercaseUrls = true);
            services.AddDbContext<Dbcontext>(options =>
            {

                options.UseNpgsql(Configuration.GetConnectionString("Db"));


            });
            services.AddMediatR(this.GetType().Assembly);

            services.AddSingleton<IActionContextAccessor,ActionContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseRequestLocalization(cfg =>
            {
                cfg.AddSupportedUICultures("az", "en");
                cfg.AddSupportedCultures("az", "en");
                cfg.RequestCultureProviders.Clear();
                cfg.RequestCultureProviders.Add(new CultureProvider());
            });

            app.UseAudit();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/coming-soon.html", async (context) =>
                {

                    using (var sr = new StreamReader("Views/Static/coming-soon.html"))
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync(sr.ReadToEnd());
                    }

                });
                //lang admin
                endpoints.MapControllerRoute(
                  name: "areas-with-lang",
                  pattern: "{lang}/{area:exists}/{controller=Dashboard}/{action=Index}/{id?}",
                  constraints: new
                  {
                      lang = "en|az|ru"
                  }
              );
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                 );
                //lang admin
                endpoints.MapControllerRoute(
                    name: "default-with-lang",
                    pattern: "{lang}/{controller=Home}/{action=Index}/{id?}",
                       constraints: new
                       {
                           lang = "en|az|ru"
                       });


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
