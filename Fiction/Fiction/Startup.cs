using Fiction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction
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
            services.AddControllersWithViews(configure => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<FictionDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FictionDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddScoped<ICharactersRepository, SqlCharactersRepository>();
            services.AddScoped<IStoryRepository, SqlStoryRepository>();
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
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.Use(request => context =>
            {
                Console.WriteLine($"Before Routing 1: {context.GetEndpoint()?.DisplayName ?? "null"}");
                return request(context);
            });

            app.UseRouting();

            app.Use(request => context =>
            {
                Console.WriteLine($"After Routing 1: {context.GetEndpoint()?.DisplayName ?? "null"}");
                return request(context);
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Use(request => context =>
            {
                Console.WriteLine($"After Endpoints 1: {context.GetEndpoint()?.DisplayName ?? "null"}");
                return request(context);
            });
        }
    }
}
