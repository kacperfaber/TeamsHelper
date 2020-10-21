using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false).AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            });

            services.AddAuthentication(options => { })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
            
            services.AddDbContext<HelperContext>(b => b.UseSqlite("Data Source=.db;", s => s.MigrationsAssembly("TeamsHelper.WebApp")));

            services.AddScoped<IClaimsIdentityGenerator, ClaimsIdentityGenerator>();
            services.AddScoped<IAuthenticationPropertiesGenerator, AuthenticationPropertiesGenerator>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserPasswordValidator, UserPasswordValidator>();
            services.AddScoped<IOAuthConfigurationProvider, OAuthConfigurationProvider>();
            services.AddScoped<IMicrosoftRedirectUrlGenerator, MicrosoftRedirectUrlGenerator>();
            services.AddScoped<IGoogleRedirectUrlGenerator, GoogleRedirectUrlGenerator>();
            services.AddScoped<IOAuthConfigurationSectionNameGenerator, OAuthConfigurationSectionNameGenerator>();
            
            services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc(x => x.MapRoute("default", "{controller}/{action}"));

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}