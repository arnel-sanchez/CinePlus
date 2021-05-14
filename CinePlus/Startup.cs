using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus
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
            services.AddControllers();
            AddSwagger(services);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CinePlusDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CinePlusContext")));
            services.AddAuthentication(IdentityConstants.ApplicationScheme);
            services.AddIdentity<User, IdentityRole>(opts =>
             {
                 opts.User.RequireUniqueEmail = true;
                 opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                 opts.Password.RequiredLength = 8;
                 opts.Password.RequireNonAlphanumeric = true;
                 opts.Password.RequireLowercase = true;
                 opts.Password.RequireUppercase = true;
                 opts.Password.RequireDigit = true;
             })
                .AddEntityFrameworkStores<CinePlusDBContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
             {
                 options.Cookie.HttpOnly = true;
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                 options.SlidingExpiration = true;
                 options.Events.OnRedirectToLogin = context =>
                 {
                     context.Response.Headers["Location"] = context.RedirectUri;
                     context.Response.StatusCode = 401;
                     return Task.CompletedTask;
                 };
             }
            );
            services.AddScoped<IAuthRepository, AuthDataAccess>();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cine+ Documentación",
                    Version = "v1",
                    Description = "Documentacion de la API de Cine+"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cine+ Documentación v1");
                c.DocumentTitle = "Cine+ Documentación v1";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
