using e_commerce_.net5.Models.DataContext;
using E_commerce_.NET5_.AppCode.Extensions;
using E_commerce_.NET5_.AppCode.Middlewares;
using E_commerce_.NET5_.AppCode.Providers;
using E_commerce_.NET5_.Models.DataContext;
using E_commerce_.NET5_.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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
using XAct;

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

            services.AddControllersWithViews(cfg =>
            {
                //  cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddNewtonsoftJson(cfg =>
                {
                    cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;



                });


            services.AddControllersWithViews();
            services.AddRouting(cfg => cfg.LowercaseUrls = true);
            services.AddDbContext<Dbcontext>(options =>
            {

                options.UseNpgsql(Configuration.GetConnectionString("Db"));


            }).AddIdentity<RiodeUser, RiodeRole>()
            .AddEntityFrameworkStores<Dbcontext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                // cfg.Password.RequiredUniqueChars = 1;   
                cfg.Password.RequiredLength = 3;
                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "abcde";
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);

            });


            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "riode";

            });

            services.AddAuthentication();// sisteme girmek ucun lazimdir
            services.AddAuthorization(cfg =>
            {
                foreach (var policyName in Program.principials)
                {
                    cfg.AddPolicy(policyName, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("SuperAdmin") || handler.User.HasClaim(policyName, "1");

                        });
                    });
                }
            }); // sistemde neyi hansi seviyyede istifade etmek ucun lazimdir

            services.AddScoped<UserManager<RiodeUser>>();
            services.AddScoped<SignInManager<RiodeUser>>();
            services.AddScoped<RoleManager<RiodeRole>>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IClaimsTransformation, AppClaimProvider>();

            services.AddMediatR(this.GetType().Assembly);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
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

            app.seedMembership();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
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
                
                #region Admin
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
                #endregion

                endpoints.MapControllerRoute(
                       name: "default-accessdenied",
                       pattern: "accessdenied.html",
                       defaults: new
                       {
                           area = "",
                           controller = "account",
                           action = "accessdenied"
                       });

                #region Home
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
                #endregion
                

            });
        }
    }
}
