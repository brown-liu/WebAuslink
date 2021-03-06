using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebAuslink.Data;
using Microsoft.AspNetCore.Identity;
using WebAuslink.Repo;
using WebAuslink.Helper;
using WebAuslink.Services;

namespace WebAuslink
{
    public class Startup
    {
        
        public Startup(IConfiguration Config,IWebHostEnvironment env)
        {
            _configuration = Config;
            _webHostEnvironment = env;
           
        }

        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _webHostEnvironment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<WebAuslinkContext>();
            services.ConfigureApplicationCookie(c =>
            {
                c.LoginPath =_configuration["Application:LoginPath"];
            });

            
            services.AddControllersWithViews();
            
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.Configure<IdentityOptions>(option =>
           {
               option.Password.RequiredLength = 4;
               option.Password.RequireDigit = false;
               option.Password.RequiredUniqueChars = 0;
               option.Password.RequireNonAlphanumeric = false;
               option.Password.RequireUppercase = false;
               option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
               option.Lockout.MaxFailedAccessAttempts = 5;

           }
            );
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IAccountRepo,AccountRepo>();
            services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IUserservice, Userservice>();
            services.AddDbContext<WebAuslinkContext>(options =>
                    options.UseSqlServer(_configuration.GetConnectionString("WebAuslinkContext")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            if (env.IsDevelopment())
            {
                
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
            app.UseAuthentication();
            dbInitializer.Initialize();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
