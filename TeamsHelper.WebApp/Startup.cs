using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
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
            services.AddLogging();
            
            services.AddHostedService<Service>();


            services.AddMvc(x => x.EnableEndpointRouting = false).AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            });

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("SecretKeys")).SetApplicationName("TeamsHelper");

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.RequireAuthenticatedSignIn = false;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Login/Login");
                    options.LogoutPath = new PathString("/Login/Logout");
                });

            services.AddAuthorization();

            services.AddDbContext<HelperContext>(b => b.UseSqlite("Data Source=.db;", s => s.MigrationsAssembly("TeamsHelper.WebApp")));

            services.AddScoped<IClaimsIdentityGenerator, ClaimsIdentityGenerator>();
            services.AddScoped<IAuthenticationPropertiesGenerator, AuthenticationPropertiesGenerator>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserPasswordValidator, UserPasswordValidator>();
            services.AddScoped<IOAuthConfigurationProvider, OAuthConfigurationProvider>();
            services.AddScoped<IMicrosoftRedirectUrlGenerator, MicrosoftRedirectUrlGenerator>();
            services.AddScoped<IGoogleRedirectUrlGenerator, GoogleRedirectUrlGenerator>();
            services.AddScoped<IOAuthConfigurationSectionNameGenerator, OAuthConfigurationSectionNameGenerator>();
            services.AddScoped<IJsonDeserializer, JsonDeserializer>();
            services.AddScoped<ITokenContentGenerator, TokenContentGenerator>();
            services.AddScoped<IFormUrlGenerator, FormUrlGenerator>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IAuthorizationGenerator, AuthorizationGenerator>();

            services.AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(new CookiePolicyOptions {MinimumSameSitePolicy = SameSiteMode.Lax});
            
            app.UseMvc(x => x.MapRoute("default", "{controller}/{action}"));
        }
    }
}